namespace EscapeTheRoomConsole
{
    public class Question
    {
        public string QuestionMessage { get; private set; }
        public string CorrectAnswer { get; private set; }

        public Question(string questionMessage, string correctAnswer)
        {
            QuestionMessage = questionMessage;
            CorrectAnswer = correctAnswer;
        }

        public bool IsCorrect(string answer)
        {
            if (string.IsNullOrEmpty(answer))
            {
                return false;
            }

            return answer.Equals(CorrectAnswer, System.StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
