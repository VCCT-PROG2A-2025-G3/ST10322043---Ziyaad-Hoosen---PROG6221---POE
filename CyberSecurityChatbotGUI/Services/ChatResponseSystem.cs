using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityChatBot.Services;

// Namespace that holds all chatbot-related service classes
namespace CyberSecurityChatBot.Services
{
    // This class controls the chatbot interaction logic
    public class ChatResponseSystem
    {
        // This variable stores the user's favorite topic, additonal point for question 4 :)
        private static string favoriteTopic = "";
        // This variable stores the last topic discussed in the chat
        private static string lastTopic = "";
        // This variable checks if the user is asking a follow-up question
        private static bool isFollowUp = false;
        // This variable checks if the next prompt should be suppressed, it skips the follow up prompt
        private static bool suppressNextPrompt = false;
        // This variable checks if the user has already been shown a reminder
        private static HashSet<string> shownReminders = new HashSet<string>();
        // This variable stores the last reminder shown to the user
        private static string lastReminderKey = "";

        // This dictionary holds various topics and their corresponding tips
        private static readonly Dictionary<string, List<string>> topicTips = new Dictionary<string, List<string>>
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



        // This method starts the chat with the user
        public static void StartChat(string userName)
        {
            // Flag to check if this is the first time we're asking a question
            bool isFirstTime = true;

            // Infinite loop for continuous chat until the user types 'exit'
            while (true)
            {
                // Draws a visual line divider
                //ConsoleUIEnhancer.PrintDivider();

                // Show a different message on the first run
                if (isFirstTime)
                {
                    //ConsoleUIEnhancer.TypingEffect($"How may I assist you today?");
                    //ConsoleUIEnhancer.TypingEffect("Type 'exit' anytime to leave the chat.");
                    // After first time, change the flag
                    isFirstTime = false;
                }
                else if (suppressNextPrompt)
                {
                    suppressNextPrompt = false; // skip this round's prompt and reset
                }
                else if (isFollowUp)
                {
                    //ConsoleUIEnhancer.TypingEffect("Would you like more help on this topic or would you like to ask about something else?");
                    isFollowUp = false;
                }
                else
                {
                    // ConsoleUIEnhancer.TypingEffect($"Would you like help with another topic, {userName}?");
                }

                // Prompt for user input
                Console.Write("> ");
                // Convert input to lowercase for easier comparison
                string input = Console.ReadLine().ToLower();

                // If user types "exit", break out of the loop and end chat
                if (InputValidator.IsExit(input))
                    break;

                // If input is empty, ask again (handled in InputValidator.cs file already)
                if (!InputValidator.IsValid(input))
                    continue;
                // Process the actual user question
                Respond(input);
            }
        }

        // This method handles how the chatbot replies based on the user's input
        private static void Respond(string input)
        {
            // Check for favorite topic declarations FIRST
            string[] favoritePatterns = {
                "i'm interested in",
                "im interested in",
                "i care about",
                "i like learning about",
                "i want to know about",
                "i want to learn about"
            };

            foreach (var pattern in favoritePatterns)
            {
                if (input.StartsWith(pattern))
                {
                    string newFavorite = input.Substring(pattern.Length).Trim();
                    if (!string.IsNullOrEmpty(newFavorite))
                    {
                        if (newFavorite != favoriteTopic)
                        {
                            favoriteTopic = newFavorite;
                            shownReminders.Clear(); // Reset reminders
                            //ConsoleUIEnhancer.TypingEffect($"Great! I'll remember that you're interested in {favoriteTopic}. It's a crucial part of staying safe online.");
                        }
                        else
                        {
                            //ConsoleUIEnhancer.TypingEffect($"Got it, you're still interested in {favoriteTopic}.");
                        }
                    }
                    //ConsoleUIEnhancer.PrintDivider();
                    return; // Stop here so the rest of Respond doesn't run
                }
            }


            // Friendly/general response
            if (input.Contains("how are you") || input.Contains("how are you doing?") || input.Contains("how're you?") || input.Contains("how you?"))
            {
                // ConsoleUIEnhancer.TypingEffect("I'm great, thanks for asking! Ready to help you stay safe online.");
            }

            // Purpose of the bot
            else if (input.Contains("your purpose") || input.Contains("what do you do"))
            {
                // ConsoleUIEnhancer.TypingEffect("I'm here to teach you about cybersecurity and help you avoid online threats.");
            }

            // If user needs help on what topics to ask about
            else if (input.Contains("what can i ask") || input.Contains("help"))
            {
                // added "scams" to the list of topics
                // ConsoleUIEnhancer.TypingEffect("You can ask me about things like phishing, password safety, safe browsing, scams and more!");
            }

            // This way, if the user says "explain that",or something relevant
            // the bot will re-use the previous keyword and give another response from the list.
            else if (input.Contains("more") || input.Contains("tell me more") || input.Contains("explain") || input.Contains("i don't understand") || input.Contains("could you elaborate"))
            {
                if (string.IsNullOrEmpty(lastTopic))
                {
                    // ConsoleUIEnhancer.TypingEffect("Could you clarify what topic you'd like more information about?");
                }
                else
                {
                    isFollowUp = true; // set flag so next prompt is different
                    Respond(lastTopic); // Call Respond again, simulating they reasked the topic
                }
            }

            // Detect and respond to user sentiment
            else if (input.Contains("worried"))
            {
                // ConsoleUIEnhancer.TypingEffect("It's completely understandable to feel that way. Cybersecurity threats can be stressful. Let me share some tips to help you stay safe.");
            }
            else if (input.Contains("frustrated"))
            {
                // ConsoleUIEnhancer.TypingEffect("I'm sorry you're feeling frustrated. Cybersecurity can be confusing, but you're not alone. I'm here to help explain things clearly.");
            }
            else if (input.Contains("curious"))
            {
                // ConsoleUIEnhancer.TypingEffect("It's great that you're curious! Learning more about cybersecurity is a smart move. Ask me anything.");
            }

            // added option to randomise responses if user input contains the keyword "Phishing"
            else if (input.Contains("phishing"))
            {
                lastTopic = "phishing";
                ShowTip("phishing");
            }


            // added option to randomise responses if user input contains the keyword "Password"
            else if (input.Contains("password"))
            {
                lastTopic = "password";
                ShowTip("password");
            }


            // added option to randomise responses if user input contains the keyword "Safe Browsing"
            else if (input.Contains("safe browsing") || input.Contains("browse safely") || input.Contains("browsing safely"))
            {
                lastTopic = "safe browsing";
                ShowTip("safe browsing");
            }



            // added keyword enhancments to include for words like; scam or privacy as i already had specific keywords for the others.
            // added option to randomise responses if user input contains the keyword "Scam"
            else if (input.Contains("scam"))
            {
                lastTopic = "scam";
                ShowTip("scam");
            }


            // added option to randomise responses if user input contains the keyword "Privacy"
            else if (input.Contains("privacy"))
            {
                lastTopic = "privacy";
                ShowTip("privacy");
            }



            // Handle follow-up confirmations
            else if (input == "yes")
            {
                // Reset lastTopic and ask user what topic they want
                lastTopic = "";
                isFollowUp = false;
                suppressNextPrompt = true;

                // ConsoleUIEnhancer.TypingEffect("Sure! What cybersecurity topic would you like help with?");
                return;
            }



            else if (input == "no")
            {
                // ConsoleUIEnhancer.TypingEffect("No problem. Let me know if there's another cybersecurity topic you'd like to explore.");
                suppressNextPrompt = true; // Skip the prompt in the next loop
            }
            else if (input.Contains("another topic") || input.Contains("new topic"))
            {
                // ConsoleUIEnhancer.TypingEffect("Alright! Please type your new question or topic.");
                suppressNextPrompt = true; //  prevents the next prompt from printing too early
            }


            // Unknown input fallback
            else
            {
                // ConsoleUIEnhancer.TypingEffect("I'm not sure how to answer that yet. Try asking about phishing, passwords, or other cybersecurity topics.");
            }

            // Add a visual break after every message
            // ConsoleUIEnhancer.PrintDivider();
        }
        // This method shows a random tip based on the topic
        private static string lastTipShown = "";

        private static void ShowTip(string topic)
        {
            if (topicTips.ContainsKey(topic))
            {
                Random rand = new Random();
                var tips = topicTips[topic];

                // Choose a new tip that isn't the same as the last one
                string selectedTip;
                do
                {
                    selectedTip = tips[rand.Next(tips.Count)];
                } while (tips.Count > 1 && selectedTip == lastTipShown);

                lastTipShown = selectedTip;
                //ConsoleUIEnhancer.TypingEffect(selectedTip);

                // Show reminder only once for each unique (topic, favoriteTopic) combination
                if (!string.IsNullOrEmpty(favoriteTopic) && topic != favoriteTopic)
                {
                    string reminderKey = $"{topic}|{favoriteTopic}";

                    if (!shownReminders.Contains(reminderKey))
                    {
                        //ConsoleUIEnhancer.TypingEffect($"As someone interested in {favoriteTopic}, you might want to explore more about it in your daily online habits.");
                        shownReminders.Add(reminderKey);
                    }
                }
            }
        }


        //-----------------------------------------------References---------------------------------------------------//
        // Declaration of Ai: ChatGPT to fix certain errors i couldn't solve
    }
}