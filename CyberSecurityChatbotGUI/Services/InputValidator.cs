using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityChatBot.Services; 

namespace CyberSecurityChatBot.Services
{
    // This class checks if the user's input is valid or if they want to exit the chat
    public class InputValidator
    {
        // Checks if the user's input is empty or just spaces
        public static bool IsValid(string input)
        {
            // If the input is empty or only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Display a friendly message asking the user to type something
                //ConsoleUIEnhancer.TypingEffect("Please type something as i am unable to respond to an empty input.");
                // Invalid input, don’t continue
                return false;
            }
            // Input is valid
            return true;
        }

        // Checks if the user wants to exit the chat by typing "exit"
        public static bool IsExit(string input)
        {
            // Remove any spaces, make lowercase, and compare to "exit"
            return input.Trim().ToLower() == "exit";
        }
    }
}
