using System.Text;
using System;
using System.Collections.Generic;

namespace EscapeTheRoomConsole.Editions
{
    public abstract class Edition
    {
        private List<Question> _questions;
        private int _maximumIncorrectAllowed;

        public Edition(List<Question> questions, int maximumIncorrectAllowed)
        {
            _questions = questions;
            _maximumIncorrectAllowed = maximumIncorrectAllowed;
        }

        public void Run()
        {
            ShowWelcomeBanner();
            ShowWelcomeMessage();

            var hasEscaped = AskQuestions();

            if (hasEscaped)
            {
                ShowEscapedBanner();
                return;
            }

            ShowFailureBanner();
        }

        private void ShowFailureBanner()
        {
            Console.WriteLine("Failuer!!!!");
        }

        private void ShowEscapedBanner()
        {
            Console.WriteLine("Escaped!!!");
        }

        private bool AskQuestions()
        {
            var numberOfIncorrectAnswers = 0;

            for(var i = 0; i < _questions.Count; i++)
            {
                var question = _questions[i];

                if (numberOfIncorrectAnswers >= _maximumIncorrectAllowed)
                {
                    return false;
                }

                Console.WriteLine($"{question.QuestionMessage}:");
                var input = Console.ReadLine();

                if (question.IsCorrect(input))
                {
                    ShowCorrectAnswerMessage(_questions.Count - i - 1);
                    continue;
                }

                numberOfIncorrectAnswers++;
                ShowIncorrectAnswerMessage(numberOfIncorrectAnswers);
                i--;
            }

            return true;
        }

        private void ShowCorrectAnswerMessage(int numberOfQuestionsLeft)
        {
            Console.WriteLine($"That is correct. {numberOfQuestionsLeft} questions left");
        }

        private void ShowIncorrectAnswerMessage(int numberOfIncorrectAnswers)
        {
            Console.WriteLine($"That is not correct. You have {_maximumIncorrectAllowed - numberOfIncorrectAnswers} incorrect guesses left.");
        }

        private void ShowWelcomeMessage()
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.AppendLine("Do you think you have what it takes to Escape the Room??");

        }

        private void ShowWelcomeBanner()
        {
            var welcomeBannerBuilder = new StringBuilder();

            welcomeBannerBuilder.AppendLine(@"
        ▓█████   ██████  ▄████▄   ▄▄▄       ██▓███  ▓█████ 
        ▓█   ▀ ▒██    ▒ ▒██▀ ▀█  ▒████▄    ▓██░  ██▒▓█   ▀ 
        ▒███   ░ ▓██▄   ▒▓█    ▄ ▒██  ▀█▄  ▓██░ ██▓▒▒███   
        ▒▓█  ▄   ▒   ██▒▒▓▓▄ ▄██▒░██▄▄▄▄██ ▒██▄█▓▒ ▒▒▓█  ▄ 
        ░▒████▒▒██████▒▒▒ ▓███▀ ░ ▓█   ▓██▒▒██▒ ░  ░░▒████▒
        ░░ ▒░ ░▒ ▒▓▒ ▒ ░░ ░▒ ▒  ░ ▒▒   ▓▒█░▒▓▒░ ░  ░░░ ▒░ ░
         ░ ░  ░░ ░▒  ░ ░  ░  ▒     ▒   ▒▒ ░░▒ ░      ░ ░  ░
           ░   ░  ░  ░  ░          ░   ▒   ░░          ░   
           ░  ░      ░  ░ ░            ░  ░            ░  ░
                        ░                                  ");

            welcomeBannerBuilder.AppendLine(@"         
                ▄▄▄█████▓ ██░ ██ ▓█████ 
                ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀ 
                ▒ ▓██░ ▒░▒██▀▀██░▒███   
                ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ 
                  ▒██▒ ░ ░▓█▒░██▓░▒████▒
                  ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░
                    ░     ▒ ░▒░ ░ ░ ░  ░
                  ░       ░  ░░ ░   ░   
                          ░  ░  ░   ░  ░");


            welcomeBannerBuilder.AppendLine(@"
             ██▀███   ▒█████   ▒█████   ███▄ ▄███▓
            ▓██ ▒ ██▒▒██▒  ██▒▒██▒  ██▒▓██▒▀█▀ ██▒
            ▓██ ░▄█ ▒▒██░  ██▒▒██░  ██▒▓██    ▓██░
            ▒██▀▀█▄  ▒██   ██░▒██   ██░▒██    ▒██ 
            ░██▓ ▒██▒░ ████▓▒░░ ████▓▒░▒██▒   ░██▒
            ░ ▒▓ ░▒▓░░ ▒░▒░▒░ ░ ▒░▒░▒░ ░ ▒░   ░  ░
              ░▒ ░ ▒░  ░ ▒ ▒░   ░ ▒ ▒░ ░  ░      ░
              ░░   ░ ░ ░ ░ ▒  ░ ░ ░ ▒  ░      ░   
               ░         ░ ░      ░ ░         ░  ");

            welcomeBannerBuilder.AppendLine(GetEditionWelcomeBanner());

            Console.WriteLine(welcomeBannerBuilder);
        }

        public abstract string GetEditionWelcomeBanner();
    }
}
