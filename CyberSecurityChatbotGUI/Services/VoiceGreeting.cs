using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace CyberSecurityChatBot.Services
{
    public class VoiceGreeting
    {
        // plays the sound,- the welcome message..
        public static void PlayWelcome()
        {
            SoundPlayer player = new SoundPlayer("welcome_message.wav");
            player.Play(); 
        }
    }
}
