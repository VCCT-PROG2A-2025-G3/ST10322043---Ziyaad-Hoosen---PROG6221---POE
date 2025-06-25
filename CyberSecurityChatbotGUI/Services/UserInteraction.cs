// using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityChatbotGUI.Services
{
    public class UserInteraction
    {
        // In GUI, we pass the name from a TextBox instead of asking in console
        public static string GetUserNameFromInput(string input)
        {
            return input?.Trim();
        }
    }
}
