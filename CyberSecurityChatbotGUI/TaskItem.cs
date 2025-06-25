using System;

namespace CyberSecurityChatbotGUI
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Reminder { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            string status = IsCompleted ? "✅" : "🕒";
            string reminderText = Reminder.HasValue ? $" (Reminds: {Reminder.Value})" : "";
            return $"{status} {Title} - {Description}{reminderText}";
        }
    }
}
