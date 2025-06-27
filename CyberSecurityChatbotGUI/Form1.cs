using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CyberSecurityChatbotGUI.Services; 


namespace CyberSecurityChatbotGUI
{
    // Main form for the Cybersecurity Chatbot GUI application
    public partial class Form1 : Form
    {
        private List<string> activityLog = new List<string>();
        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
        private int currentQuizIndex = 0;
        private int score = 0;
        List<TaskItem> tasks = new List<TaskItem>();

        // Part 1/2 chatbot logic fields
        private string userName = "";
        private string favoriteTopic = "";
        private string lastTopic = "";
        private bool isFollowUp = false;
        private bool suppressNextPrompt = false;
        private HashSet<string> shownReminders = new HashSet<string>();
        private string lastTipShown = "";

        // creating feilds for guided tasks
        private enum TaskCreationStep { None, Title, Description, Reminder }
        private TaskCreationStep awaitingTaskStep = TaskCreationStep.None;
        private string tempTaskTitle = "";
        private string tempTaskDescription = "";

        // Constructor for the main form
        public Form1()
        {
            // Initialize the form components
            InitializeComponent();

            // Show landing only, hide everything else (when running the program)
            pnlLanding.Visible = true;
            pnlChat.Visible = false;
            pnlTasks.Visible = false;
            pnlQuiz.Visible = false;
            pnlLog.Visible = false;
            btnStartQuiz.Click += btnStartQuiz_Click;


            // Wire up navigation buttons
            btnGoToTasks.Click += (s, e) =>
            {
                pnlLanding.Visible = false;
                pnlTasks.Visible = true;
                pnlChat.Visible = false;
                pnlQuiz.Visible = false;
            };
            
            btnGoToQuiz.Click += (s, e) =>
            {
                pnlLanding.Visible = false;
                pnlQuiz.Visible = true;
                pnlChat.Visible = false;
                pnlTasks.Visible = false;
            };

            btnGoToChat.Click += (s, e) =>
            {
                pnlLanding.Visible = false;
                pnlChat.Visible = true;
                pnlTasks.Visible = false;
                pnlQuiz.Visible = false;
                PlayWelcomeSound(); 
            };


            btnGoToLog.Click += (s, e) => ShowPanel("log");

        }

        // Button click handler to start the quiz
        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            grpQuiz.Visible = true;
            LoadQuizQuestions();
            currentQuizIndex = 0;
            score = 0;
            ShowNextQuizQuestion();
            AppendToChat("Bot", "Starting quiz via button!");
        }

        // Method to show the appropriate panel based on the name
        private void ShowPanel(string name)
        {
            pnlLanding.Visible = (name == "landing");
            pnlChat.Visible = (name == "chat");
            pnlTasks.Visible = (name == "tasks");
            pnlQuiz.Visible = (name == "quiz");
            pnlLog.Visible = (name == "log");
                        
            if (name == "log")
            {
                ShowActivityLog(); 
            }

            // if chat button is tapped the system outputs a greeting followed by a prompt asking user for his/her name
            if (name == "chat" && string.IsNullOrEmpty(userName) && !chatHistoryBox.Text.Contains("Hi! What's your name?"))
            {
                AppendToChat("Bot", "Hi! What's your name?");
            }


        }

        // Method to show the activity log in the log panel
        private void ShowActivityLog()
        {
            if (activityLog.Count == 0)
            {
                // if the log is empty the activity log will read: 
                logBox.Text = "No actions recorded yet.";
            }
            else
            {
                var recent = activityLog.Skip(Math.Max(0, activityLog.Count - 10)).ToList();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Recent Activity:");
                for (int i = 0; i < recent.Count; i++)
                {
                    sb.AppendLine($"{i + 1}. {recent[i]}");
                }
                logBox.Text = sb.ToString();
            }
        }

        // Button click handler to add a new task
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime? reminder = dtpReminder.Value;

            // asks user to enter a task name if the user wanted to add a task
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            TaskItem newTask = new TaskItem
            {
                Title = title,
                Description = description,
                Reminder = reminder
            };

            // if the user did not enter a reminder, the system will set it to null 
            tasks.Add(newTask);
            activityLog.Add($"Task added: {title} (Reminder: {reminder})");
            RefreshTaskList();
            txtTitle.Clear();
            txtDescription.Clear();

        }

        // Method to refresh the task list displayed in the task list box
        private void RefreshTaskList()
        {
            taskListBox.Items.Clear();
            foreach (var task in tasks)
            {
                taskListBox.Items.Add(task.ToString());
            }
        }

        // Button click handler to mark a task as complete
        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            
            if (taskListBox.SelectedIndex >= 0)
            {
                // marks the task as completed
                tasks[taskListBox.SelectedIndex].IsCompleted = true;  
                RefreshTaskList();
            }
        }

        // Button click handler to delete a selected task
        private void btnDeletTask_Click(object sender, EventArgs e)
        {
            if (taskListBox.SelectedIndex >= 0)
            {
                // removes the selected task from the list
                tasks.RemoveAt(taskListBox.SelectedIndex);
                RefreshTaskList();
            }

        }

        // Timer tick handler to check for task reminders
        private void reminderTimer_Tick(object sender, EventArgs e)
        {
            foreach (var task in tasks)
            {
                // Check if the task has a reminder set and if the current time is past the reminder time
                if (task.Reminder.HasValue && DateTime.Now >= task.Reminder.Value)
                {
                    string key = $"{task.Title}|{task.Reminder}";

                    if (!shownReminders.Contains(key))
                    {
                        // Show a reminder message box for the task
                        MessageBox.Show(
                            $"Reminder: {task.Title}\n\n{task.Description}",
                            "Task Reminder",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Add to activity log
                        shownReminders.Add(key);
                    }
                }
            }
        }

        // KeyDown event handler for the user input box to handle Enter key clicks
        private void userInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            // If the Enter key is pressed, process the input
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string userInput = userInputBox.Text.Trim();
                userInputBox.Clear();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    AppendToChat("Bot", "Please enter a message so I can help you.");
                    return;
                }

                AppendToChat("User", userInput);

                // Greeting logic
                if (string.IsNullOrEmpty(userName))
                {
                    // If the user hasn't provided their name yet, ask for it
                    userName = userInput;
                    AppendToChat("Bot", $"Nice to meet you, {userName}! Ask me anything about cybersecurity.");
                    return;
                }

                // Handle guided task creation
                if (awaitingTaskStep == TaskCreationStep.Title)
                {
                    tempTaskTitle = userInput;
                    awaitingTaskStep = TaskCreationStep.Description;
                    AppendToChat("Bot", "Got it. And the description?");
                    return;
                }

                // If the user is in the task creation process, handle the steps accordingly
                else if (awaitingTaskStep == TaskCreationStep.Description)
                {
                    tempTaskDescription = userInput;
                    awaitingTaskStep = TaskCreationStep.Reminder;
                    AppendToChat("Bot", "When should I remind you? (e.g., 'in 2 hours', 'tomorrow morning')");
                    return;
                }

                // If the user is in the task creation process and has provided a reminder
                else if (awaitingTaskStep == TaskCreationStep.Reminder)
                {
                    DateTime reminder;
                    if (!TryParseCasualReminder(userInput, out reminder))
                    {
                        // If the input is not a valid reminder, set a default reminder (in one min)
                        reminder = DateTime.Now.AddMinutes(1);
                        AppendToChat("Bot", "I couldn’t understand the time — I’ll set the reminder for 1 minute from now.");
                    }

                    // If the reminder is in the past, set it to now
                    else
                    {
                        AppendToChat("Bot", $"Reminder set for {reminder}");
                    }

                    // Create the task item and add it to the list
                    TaskItem task = new TaskItem
                    {
                        // Set the task title and description
                        Title = tempTaskTitle,
                        Description = tempTaskDescription,
                        Reminder = reminder
                    };

                    // Add the task to the list and log the activity
                    tasks.Add(task);
                    activityLog.Add($"Task added via chat: {tempTaskTitle} ({reminder})");
                    RefreshTaskList();
                    AppendToChat("Bot", $"Your task '{tempTaskTitle}' has been added and I’ll remind you!");

                    // Reset the task creation state
                    awaitingTaskStep = TaskCreationStep.None;
                    return;
                }


                // Continue to response handler
                HandleBotResponse(userInput);
            }
        }

        // Method to add new messages to the chat history box
        private void AppendToChat(string sender, string message)
        {
            chatHistoryBox.AppendText($"{sender}: {message}\n");
        }

        // Method to play a welcome sound when the chat panel is opened (from parts 1 and 2)
        private void PlayWelcomeSound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer(Application.StartupPath + @"\welcome_message.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sound error: " + ex.Message);
            }
        }

        // Method to handle the bot's response based on user input
        private void HandleBotResponse(string input)
        {
            // Check if the user is trying to create a task using natural language processing
            if (input.ToLower().Contains("i want to add a task") || input.ToLower().Contains("create a task") || input.ToLower().Contains("make a task"))
            {
                awaitingTaskStep = TaskCreationStep.Title;
                AppendToChat("Bot", "Sure! What’s the title of your task?");
                return;
            }

            // Check if the user is trying to set a reminder casually
            if (input.ToLower().Contains("hello"))
            {
                AppendToChat("Bot", "Hi there! How can I help you with cybersecurity today?");
            }

            
            else if (input.ToLower().StartsWith("add task:"))
            {
                try
                {
                    // Format: Add task: Title | Description | DateTime
                    string[] parts = input.Substring(9).Split('|');
                    string title = parts[0].Trim();
                    string description = parts.Length > 1 ? parts[1].Trim() : "";
                    DateTime? reminder = null;

                    // If a reminder is provided, parse it
                    if (parts.Length > 2 && DateTime.TryParse(parts[2].Trim(), out DateTime parsedDate))
                    {
                        reminder = parsedDate;
                    }

                    // Create the new task item and add it to the list
                    TaskItem newTask = new TaskItem
                    {
                        Title = title,
                        Description = description,
                        Reminder = reminder
                    };

                    // Add the task to the list and refresh the display
                    tasks.Add(newTask);
                    RefreshTaskList();

                    // Log the activity and show confirmation in the chat
                    string confirmation = $"Task '{title}' added";
                    if (reminder.HasValue)
                        confirmation += $" with reminder set for {reminder.Value}.";

                    AppendToChat("Bot", confirmation);
                    activityLog.Add($"Task added via chatbot: {title} (Reminder: {reminder})");

                }

                // If the input format is incorrect, show an error message
                catch
                {
                    AppendToChat("Bot", "Sorry, I couldn't understand that format. Use: Add task: Title | Description | DateTime");
                }
                return; 
            }

            // Handle emotional responses
            if (input.Contains("how are you"))
            {
                AppendToChat("Bot", $"I'm great, thanks for asking {userName}! Ready to help you stay safe online.");
                return;
            }
            else if (input.Contains("worried"))
            {
                AppendToChat("Bot", "It's okay to be worried. Cybersecurity can be scary, but I'm here to guide you.");
                return;
            }
            else if (input.Contains("frustrated"))
            {
                AppendToChat("Bot", "I'm sorry you're feeling frustrated. You're doing your best — keep going!");
                return;
            }
            else if (input.Contains("curious"))
            {
                AppendToChat("Bot", "I love that you're curious! Ask me anything about cybersecurity.");
                return;
            }

            // Handle favorite topic declaration
            string[] favoritePatterns = {
                "i'm interested in", "im interested in",
                "i care about", "i like learning about",
                "i want to know about", "i want to learn about"
};
            // Check if the input starts with any of the favorite patterns
            foreach (var pattern in favoritePatterns)
            {
                // If the input starts with a favorite pattern, extract the topic
                if (input.StartsWith(pattern))
                {
                    // Extract the topic after the pattern
                    string newFavorite = input.Substring(pattern.Length).Trim();
                    if (!string.IsNullOrEmpty(newFavorite))
                    {
                        // If the new favorite topic is different from the current one, update it
                        favoriteTopic = newFavorite;
                        shownReminders.Clear();
                        AppendToChat("Bot", $"Great! I'll remember that you're interested in {favoriteTopic}. It’s important to stay informed.");
                        activityLog.Add($"User favorited topic: {favoriteTopic}");

                    }
                    
                    return;
                }
            }

            // Handle topic tips
            string lower = input.ToLower();
            if (lower.Contains("phishing"))
            {
                lastTopic = "phishing";
                ShowTip("phishing");
                return;
            }
            else if (lower.Contains("password"))
            {
                lastTopic = "password";
                ShowTip("password");
                return;
            }
            else if (lower.Contains("safe browsing"))
            {
                lastTopic = "safe browsing";
                ShowTip("safe browsing");
                return;
            }
            else if (lower.Contains("scam"))
            {
                lastTopic = "scam";
                ShowTip("scam");
                return;
            }
            else if (lower.Contains("privacy"))
            {
                lastTopic = "privacy";
                ShowTip("privacy");
                return;
            }

            // Handle specific commands and questions
            else if (input.ToLower().Contains("show tasks") || input.ToLower().Contains("list tasks") || input.ToLower().Contains("what tasks"))
            {
                if (tasks.Count == 0)
                {
                    AppendToChat("Bot", "You have no tasks at the moment.");
                }

                else
                {
                    // Format the task list for display
                    StringBuilder taskList = new StringBuilder();
                    int index = 1;
                    foreach (var task in tasks)
                    {
                        string reminder = task.Reminder.HasValue ? $" (Reminds: {task.Reminder.Value})" : "";
                        string status = task.IsCompleted ? "✅" : "🕒";
                        taskList.AppendLine($"{index}. {status} {task.Title} - {task.Description}{reminder}");
                        index++;
                    }

                    AppendToChat("Bot", taskList.ToString());
                }
            }

            
            else if (input.ToLower().Contains("start quiz"))
            {
                LoadQuizQuestions();
                currentQuizIndex = 0;
                score = 0;
                ShowNextQuizQuestion();
                AppendToChat("Bot", "Starting cybersecurity quiz! First question on the way...");
                ShowPanel("quiz");
            }
            else if (input.ToLower().StartsWith("remind me to"))
            {
                try
                {
                    string title = input.Substring("remind me to".Length).Trim();
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        // If the title is empty, ask for clarification
                        AppendToChat("Bot", "Sure — remind you to do what?");
                        return;
                    }

                    // default = 1 min from now
                    DateTime reminderTime = DateTime.Now.AddMinutes(1);

                    // Try to parse a casual reminder time
                    TaskItem newTask = new TaskItem
                    {
                        Title = title,
                        Description = "(added via NLP)",
                        Reminder = reminderTime
                    };

                    // Add the new task to the list and log the activity
                    tasks.Add(newTask);
                    activityLog.Add($"NLP Task added: {title} (Reminder in 1 min)");
                    RefreshTaskList();
                    AppendToChat("Bot", $"Got it! I’ll remind you to '{title}' in 1 minute.");
                }
                catch
                {
                    // If there was an error parsing the reminder, show an error message
                    AppendToChat("Bot", "Sorry, I couldn’t understand what to remind you about.");
                }
            }

            
            else if (input.ToLower().Contains("delete task"))
            {
                string title = input.Replace("delete task", "").Trim().ToLower();                
                var match = tasks.FirstOrDefault(t => t.Title.ToLower().Contains(title));
                if (match != null)
                {
                    // Remove the matched task from the list
                    tasks.Remove(match);
                    RefreshTaskList();
                    AppendToChat("Bot", $"Deleted task: '{match.Title}'.");
                    activityLog.Add($"Task deleted via chatbot: {match.Title}");

                }
                else
                {
                    // If no matching task is found, show an error message
                    AppendToChat("Bot", $"Couldn’t find a task matching '{title}'.");
                }
            }
            // Handle marking a task as done
            else if (input.ToLower().Contains("mark task") && input.ToLower().Contains("as done"))
            {
                // Extract the task title from the input
                string title = input.Replace("mark task", "").Replace("as done", "").Trim().ToLower();
                var match = tasks.FirstOrDefault(t => t.Title.ToLower().Contains(title));
                if (match != null)
                {
                    // Mark the matched task as completed
                    match.IsCompleted = true;
                    RefreshTaskList();
                    AppendToChat("Bot", $"Marked task '{match.Title}' as completed. ✅");
                    activityLog.Add($"Task marked as complete via chatbot: {match.Title}");

                }
                else
                {
                    // If no matching task is found, show an error message
                    AppendToChat("Bot", $"Couldn’t find a task to mark as done for '{title}'.");
                }
            }

            
            else if (input.ToLower().Contains("show activity log") || input.ToLower().Contains("what have you done"))
            {
                // Show the last 5 actions recorded in the activity log
                if (activityLog.Count == 0)
                {
                    AppendToChat("Bot", "No actions recorded yet.");
                }
                else
                {
                    // Get the last 5 actions and format them for display
                    var recent = activityLog.Skip(Math.Max(0, activityLog.Count - 5)).ToList();
                    StringBuilder log = new StringBuilder();
                    log.AppendLine("Here’s a summary of recent actions:");
                    for (int i = 0; i < recent.Count; i++)
                    {
                        log.AppendLine($"{i + 1}. {recent[i]}");
                    }
                    AppendToChat("Bot", log.ToString());
                }
            }

            else if (input.ToLower().Contains("what is 2fa") || input.ToLower().Contains("2fa meaning"))
            {
                AppendToChat("Bot", "2FA (Two-Factor Authentication) adds an extra layer of protection by requiring something you know (password) and something you have (like a code or app).");
                activityLog.Add("Explained 2FA to user.");
            }

            
            else if (input.ToLower().Contains("password tip") || input.ToLower().Contains("secure password"))
            {
                AppendToChat("Bot", "Use a mix of upper/lowercase letters, numbers, and symbols. Avoid personal info and never reuse passwords.");
                activityLog.Add("User asked for password tips.");
            }

            else if (input.ToLower().Contains("hacked") || input.ToLower().Contains("i got hacked"))
            {
                AppendToChat("Bot", "Change your passwords immediately, enable 2FA, scan your device for malware, and notify affected services.");
                activityLog.Add("User asked what to do after being hacked.");
            }

            else
            {
                AppendToChat("Bot", "Sorry, I didn’t understand that.");
            }

        }

        // Method to load quiz questions into the quizQuestions list
        private void LoadQuizQuestions()
        {
            // Initialize the quiz questions list with predefined questions
            quizQuestions = new List<QuizQuestion>
    {
                // Example quiz questions
        new QuizQuestion("What should you do if you get a suspicious email?", new[] {
            "Open it", "Click the link", "Report it as phishing", "Forward it to a friend"
        }, 2),

        new QuizQuestion("True or False: '123456' is a strong password.", new[] {
            "True", "False"
        }, 1),

        new QuizQuestion("What does 2FA stand for?", new[] {
            "Two-Factor Authentication", "Two-Faced Account", "Twice Forced Access", "Too Fast Authorization"
        }, 0),

        new QuizQuestion("Which of these is a secure password?", new[] {
            "qwerty123", "MyDog123", "Welcome123", "X8#k@2!z"
        }, 3),

        new QuizQuestion("Which of the following is a phishing attempt?", new[] {
            "A text from your bank asking to confirm your details via link",
            "A social media notification",
            "A calendar reminder",
            "An Amazon order confirmation"
        }, 0),

        new QuizQuestion("True or False: You should use the same password for all accounts.", new[] {
            "True", "False"
        }, 1),

        new QuizQuestion("What’s the safest way to store your passwords?", new[] {
            "Write them in Notes app", "Use a password manager", "Memorize everything", "Email them to yourself"
        }, 1),

        new QuizQuestion("What does a secure website URL start with?", new[] {
            "http://", "www.", "https://", "ftp://"
        }, 2),

        new QuizQuestion("Which of these is an example of social engineering?", new[] {
            "Phishing email", "Strong encryption", "Firewall update", "Multi-factor login"
        }, 0),

        new QuizQuestion("How often should you update your antivirus software?", new[] {
            "Yearly", "Only when infected", "Monthly", "Regularly/automatically"
        }, 3)
    };
        }

        // Dictionary to hold tips for different topics (from part 2)
        private Dictionary<string, List<string>> topicTips = new Dictionary<string, List<string>>
        {
            ["phishing"] = new List<string>
    {
        "Be cautious of emails asking for personal information...",
        "Avoid clicking suspicious links or downloading attachments from unknown sources.",
        "Check the sender's email address closely – attackers often use slight misspellings.",
        "Never enter sensitive information on websites you accessed through suspicious emails.",
        "Use spam filters and keep your antivirus software updated."
    },
            ["password"] = new List<string>
    {
        "Use strong, unique passwords for each account.",
        "Avoid using personal details like birthdays or names in your passwords.",
        "Use a password manager to keep track of complex passwords.",
        "Change your passwords regularly to enhance security.",
        "Enable two-factor authentication whenever possible."
    },
            ["scam"] = new List<string>
    {
        "Always verify emails or messages that request money or personal information.",
        "Be skeptical of deals that seem too good to be true.",
        "Don’t trust caller ID, scammers can fake phone numbers.",
        "Avoid sending money to strangers online.",
        "Report suspicious activity to your local cybercrime authority."
    },
            ["privacy"] = new List<string>
    {
        "Limit what personal details you share on public social platforms.",
        "Regularly review and update app and browser permissions.",
        "Use secure, encrypted messaging apps for private conversations.",
        "Avoid using public Wi-Fi without a VPN.",
        "Disable location tracking when not needed."
    },
            ["safe browsing"] = new List<string>
    {
        "Avoid clicking on pop-ups or unknown ads while browsing.",
        "Always check if a website uses HTTPS before entering personal info.",
        "Keep your browser and extensions up to date to patch security flaws.",
        "Don’t download files from untrusted or suspicious websites.",
        "Use an ad blocker and antivirus software for safer browsing."
    }
        };

        // Method to show a random tip for a given topic (from part 2)
        private void ShowTip(string topic)
        {
            // Check if the topic exists in the dictionary
            if (topicTips.ContainsKey(topic))
            {
                // If the topic is valid, show a random tip
                Random rand = new Random();
                var tips = topicTips[topic];

                // Ensure the tip is not the same as the last shown tip
                string selectedTip;
                do
                {
                    selectedTip = tips[rand.Next(tips.Count)];
                } while (tips.Count > 1 && selectedTip == lastTipShown);

                // adD the tip to the chat history
                lastTipShown = selectedTip;
                AppendToChat("Bot", selectedTip);
                activityLog.Add($"Tip shown for topic: {topic}");

                // If the user has a favorite topic, show a reminder to explore it
                if (!string.IsNullOrEmpty(favoriteTopic) && topic != favoriteTopic)
                {
                    // Create a unique key for the reminder to avoid duplicates
                    string reminderKey = $"{topic}|{favoriteTopic}";
                    if (!shownReminders.Contains(reminderKey))
                    {
                        // add reminder to the chat history
                        AppendToChat("Bot", $"As someone interested in {favoriteTopic}, you might want to explore more about it in your daily online habits.");
                        shownReminders.Add(reminderKey);
                    }
                }
            }
        }

        // Method to show the next quiz question.
        private void ShowNextQuizQuestion()
        {
            // If the quiz is already completed, do nothing
            activityLog.Add("Quiz started - 10 questions");

            // If there are still questions left, display the next one
            if (currentQuizIndex < quizQuestions.Count)
            {
                var q = quizQuestions[currentQuizIndex];
                lblQuestion.Text = q.QuestionText;

                // Set option texts
                rdoOption1.Text = q.Options.Length > 0 ? q.Options[0] : "";
                rdoOption1.Visible = q.Options.Length > 0;

                rdoOption2.Text = q.Options.Length > 1 ? q.Options[1] : "";
                rdoOption2.Visible = q.Options.Length > 1;

                rdoOption3.Text = q.Options.Length > 2 ? q.Options[2] : "";
                rdoOption3.Visible = q.Options.Length > 2;

                rdoOption4.Text = q.Options.Length > 3 ? q.Options[3] : "";
                rdoOption4.Visible = q.Options.Length > 3;

                // Clear previous selection + feedback
                rdoOption1.Checked = false;
                rdoOption2.Checked = false;
                rdoOption3.Checked = false;
                rdoOption4.Checked = false;
                lblFeedback.Text = "";
            }
            // If all questions have been answered, show the final score
            else
            {
                activityLog.Add($"Quiz completed - Score: {score}/{quizQuestions.Count}");
                lblQuestion.Text = "Quiz complete!";
                lblFeedback.Text = $"You scored {score} out of {quizQuestions.Count}.";
                AppendToChat("Bot", $"You completed the quiz with a score of {score}/{quizQuestions.Count}!");
            }
        }

        // Button click handler to submit the selected answer in the quiz
        private void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            
            if (currentQuizIndex >= quizQuestions.Count)
                return;

            // Get the current question and the selected answer index
            var question = quizQuestions[currentQuizIndex];
            int selectedIndex = -1;

            // Check which radio button is selected
            if (rdoOption1.Checked) selectedIndex = 0;
            else if (rdoOption2.Checked) selectedIndex = 1;
            else if (rdoOption3.Checked) selectedIndex = 2;
            else if (rdoOption4.Checked) selectedIndex = 3;

            // If no option is selected, show a message and return
            if (selectedIndex == -1)
            {
                MessageBox.Show("Please select an option.");
                return;
            }

            // Check if the selected answer is correct and provide feedback
            if (selectedIndex == question.CorrectOptionIndex)
            {
                lblFeedback.Text = "Correct! ✅";
                score++;
            }
            // If the answer is incorrect, show the correct answer
            else
            {
                lblFeedback.Text = $"Incorrect. ❌ Correct answer: {question.Options[question.CorrectOptionIndex]}";
            }

            // Move to the next question after a short delay
            currentQuizIndex++;
            Task.Delay(1500).ContinueWith(_ =>
            {
                // Invoke the UI thread to update the quiz question
                Invoke(new Action(() =>
                {
                    ShowNextQuizQuestion();
                }));
            });
        }

        // Navigation button click handlers to switch between panels
        private void btnNavHome_Click(object sender, EventArgs e) => ShowPanel("landing");
        private void btnNavChat_Click(object sender, EventArgs e) => ShowPanel("chat");
        private void btnNavTasks_Click(object sender, EventArgs e) => ShowPanel("tasks");
        private void btnNavQuiz_Click(object sender, EventArgs e) => ShowPanel("quiz");
        private void btnNavLog_Click(object sender, EventArgs e) => ShowPanel("log");

        // Method to parse casual reminder input 
        private bool TryParseCasualReminder(string input, out DateTime result)
        {
            // Initialize the result to the current time
            input = input.ToLower();
            result = DateTime.Now;

            // Try to parse the input and adjust the result accordingly
            try
            {
                if (input.StartsWith("in "))
                {
                    // Extract the time part after "in "
                    string time = input.Substring(3).Trim();
                    if (time.EndsWith("minutes"))
                        result = result.AddMinutes(Convert.ToInt32(time.Replace("minutes", "").Trim()));
                    else if (time.EndsWith("hours"))
                        result = result.AddHours(Convert.ToInt32(time.Replace("hours", "").Trim()));
                    else
                        return false;
                }
                
                else if (input.Contains("tomorrow morning"))
                {
                    result = result.Date.AddDays(1).AddHours(8);
                }
                else if (input.Contains("tomorrow afternoon"))
                {
                    result = result.Date.AddDays(1).AddHours(14);
                }
                else if (input.Contains("today afternoon"))
                {
                    result = result.Date.AddHours(14);
                }
                else
                {
                    result = DateTime.Parse(input);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


    }

}
//-----------------------References throughout the code:----------------------------------------------//
//1. Microsoft Learn – C# Guide
//[https://learn.microsoft.com/en-us/dotnet/csharp/]
// 2. Microsoft Learn – Windows Forms(WinForms)
// [https://learn.microsoft.com/en-us/dotnet/desktop/winforms/?view=netdesktop-8.0]
// 3.W3Schools – C# Tutorial
// [https://www.w3schools.com/cs/index.php]
// 4.Stack Overflow
// [https://stackoverflow.com/]
// 5. GeeksforGeeks – C# Programming
// [https://www.geeksforgeeks.org/csharp-programming-language/]
// 6. TutorialsTeacher – C# Basics
// [https://www.tutorialsteacher.com/csharp]

// IBM – What is Natural Language Processing(NLP)?
// [https://www.ibm.com/topics/natural-language-processing]
