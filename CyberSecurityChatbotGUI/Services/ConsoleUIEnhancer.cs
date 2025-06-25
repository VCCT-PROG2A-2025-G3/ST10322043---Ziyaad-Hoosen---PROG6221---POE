using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// This library gives us fancy console styling like colors, panels, and borders
// using Spectre.Console;

namespace CyberSecurityChatbotGUI.Services
{
    public class ConsoleUIEnhancer
    {
        // Optional: Simulate typing effect in a Label or TextBox
        public static string TypingEffect(string message, int delay = 30)
        {
            string result = "";
            foreach (char c in message)
            {
                result += c;
                Thread.Sleep(delay); // Can be removed for instant text
            }
            return result;
        }
    }
}