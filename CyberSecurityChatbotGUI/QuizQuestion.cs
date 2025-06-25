namespace CyberSecurityChatbotGUI
{
    public class QuizQuestion
    {
        public string QuestionText { get; set; }
        public string[] Options { get; set; }
        public int CorrectOptionIndex { get; set; } // 0-based index

        public QuizQuestion(string question, string[] options, int correctIndex)
        {
            QuestionText = question;
            Options = options;
            CorrectOptionIndex = correctIndex;
        }
    }
}
