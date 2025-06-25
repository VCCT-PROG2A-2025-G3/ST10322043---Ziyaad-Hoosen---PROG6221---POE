using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CyberSecurityChatbotGUI.Services; // (if needed for future logic)


namespace CyberSecurityChatbotGUI
{
    public partial class Form1 : Form
    {
        private List<string> activityLog = new List<string>();
        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
        private int currentQuizIndex = 0;
        private int score = 0;
        List<TaskItem> tasks = new List<TaskItem>();

        public Form1()
        {
            InitializeComponent();
            userInputBox.KeyDown += userInputBox_KeyDown;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime? reminder = dtpReminder.Value;

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

            tasks.Add(newTask);
            activityLog.Add($"Task added: {title} (Reminder: {reminder})");
            RefreshTaskList();
            txtTitle.Clear();
            txtDescription.Clear();

            }
        private void RefreshTaskList()
        {
            taskListBox.Items.Clear();
            foreach (var task in tasks)
            {
                taskListBox.Items.Add(task.ToString());
            }
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (taskListBox.SelectedIndex >= 0)
            {
                tasks[taskListBox.SelectedIndex].IsCompleted = true;  // ✅ mark as done
                RefreshTaskList();
            }
        }


        private void btnDeletTask_Click(object sender, EventArgs e)
        {
            if (taskListBox.SelectedIndex >= 0)
            {
                tasks.RemoveAt(taskListBox.SelectedIndex);
                RefreshTaskList();
            }

        }

        private HashSet<string> shownReminders = new HashSet<string>();

        private void reminderTimer_Tick(object sender, EventArgs e)
        {
            foreach (var task in tasks)
            {
                if (task.Reminder.HasValue && DateTime.Now >= task.Reminder.Value)
                {
                    string key = $"{task.Title}|{task.Reminder}";

                    if (!shownReminders.Contains(key))
                    {
                        MessageBox.Show(
                            $"Reminder: {task.Title}\n\n{task.Description}",
                            "Task Reminder",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        shownReminders.Add(key);
                    }
                }
            }
        }
        private void userInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent ding sound
                string userInput = userInputBox.Text.Trim();
                userInputBox.Clear();

                if (!string.IsNullOrEmpty(userInput))
                {
                    AppendToChat("User", userInput);
                    HandleBotResponse(userInput);
                }
            }
        }
        private void AppendToChat(string sender, string message)
        {
            chatHistoryBox.AppendText($"{sender}: {message}\n");
        }

        private void HandleBotResponse(string input)
        {
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

                    if (parts.Length > 2 && DateTime.TryParse(parts[2].Trim(), out DateTime parsedDate))
                    {
                        reminder = parsedDate;
                    }

                    TaskItem newTask = new TaskItem
                    {
                        Title = title,
                        Description = description,
                        Reminder = reminder
                    };

                    tasks.Add(newTask);
                    RefreshTaskList();

                    string confirmation = $"Task '{title}' added";
                    if (reminder.HasValue)
                        confirmation += $" with reminder set for {reminder.Value}.";

                    AppendToChat("Bot", confirmation);
                }
                catch
                {
                    AppendToChat("Bot", "Sorry, I couldn't understand that format. Use: Add task: Title | Description | DateTime");
                }
            }

            else if (input.ToLower().Contains("show tasks") || input.ToLower().Contains("list tasks") || input.ToLower().Contains("what tasks"))
            {
                if (tasks.Count == 0)
                {
                    AppendToChat("Bot", "You have no tasks at the moment.");
                }
                
                else
                {
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
                grpQuiz.Visible = true;
            }
            else if (input.ToLower().StartsWith("remind me to"))
            {
                try
                {
                    string title = input.Substring("remind me to".Length).Trim();
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        AppendToChat("Bot", "Sure — remind you to do what?");
                        return;
                    }

                    DateTime reminderTime = DateTime.Now.AddMinutes(1); // default = 1 min from now

                    TaskItem newTask = new TaskItem
                    {
                        Title = title,
                        Description = "(added via NLP)",
                        Reminder = reminderTime
                    };

                    tasks.Add(newTask);
                    activityLog.Add($"NLP Task added: {title} (Reminder in 1 min)");
                    RefreshTaskList();
                    AppendToChat("Bot", $"Got it! I’ll remind you to '{title}' in 1 minute.");
                }
                catch
                {
                    AppendToChat("Bot", "Sorry, I couldn’t understand what to remind you about.");
                }
            }

            else if (input.ToLower().StartsWith("delete task:"))
            {
                string taskTitle = input.Substring("delete task:".Length).Trim().ToLower();
                var taskToRemove = tasks.FirstOrDefault(t => t.Title.ToLower() == taskTitle);

                if (taskToRemove != null)
                {
                    tasks.Remove(taskToRemove);
                    RefreshTaskList();
                    AppendToChat("Bot", $"Task '{taskToRemove.Title}' has been deleted.");
                }
                else
                {
                    AppendToChat("Bot", $"I couldn’t find a task called '{taskTitle}'.");
                }
            }

            else if (input.ToLower().Contains("show activity log") || input.ToLower().Contains("what have you done"))
            {
                if (activityLog.Count == 0)
                {
                    AppendToChat("Bot", "No actions recorded yet.");
                }
                else
                {
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

        private void LoadQuizQuestions()
        {
            quizQuestions = new List<QuizQuestion>
    {
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


        private void ShowNextQuizQuestion()
        {
            activityLog.Add("Quiz started - 10 questions");

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
            else
            {
                activityLog.Add($"Quiz completed - Score: {score}/{quizQuestions.Count}");
                lblQuestion.Text = "Quiz complete!";
                lblFeedback.Text = $"You scored {score} out of {quizQuestions.Count}.";
                AppendToChat("Bot", $"You completed the quiz with a score of {score}/{quizQuestions.Count}!");
            }
        }

        private void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            if (currentQuizIndex >= quizQuestions.Count)
                return;

            var question = quizQuestions[currentQuizIndex];
            int selectedIndex = -1;

            if (rdoOption1.Checked) selectedIndex = 0;
            else if (rdoOption2.Checked) selectedIndex = 1;
            else if (rdoOption3.Checked) selectedIndex = 2;
            else if (rdoOption4.Checked) selectedIndex = 3;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Please select an option.");
                return;
            }

            if (selectedIndex == question.CorrectOptionIndex)
            {
                lblFeedback.Text = "Correct! ✅";
                score++;
            }
            else
            {
                lblFeedback.Text = $"Incorrect. ❌ Correct answer: {question.Options[question.CorrectOptionIndex]}";
            }

            currentQuizIndex++;
            Task.Delay(1500).ContinueWith(_ =>
            {
                Invoke(new Action(() =>
                {
                    ShowNextQuizQuestion();
                }));
            });
        }

    }
}
