using System;

namespace Notatnik_parser.MainMenu
{
    public class MainMenu
    {
        public void Run()
        {
            ShowInitInfo();

            Console.ReadKey();
        }

        public void ShowInitInfo()
        {
            Console.WriteLine("Witaj w aplikacji Notatnik/Parser");
            Console.WriteLine("Wybierz co chcesz robić:");
            Console.WriteLine("1 - notatnik");
            Console.WriteLine("2 - parser XML");
            Console.WriteLine("3 - kreator XML");

            MenageUserInput();
        }

        private void MenageUserInput()
        {
            string insertValue;
            do
            {
                insertValue = Console.ReadLine();

            } while (!IsUserInputValid(insertValue));
        }

        private bool IsUserInputValid(string userInput)
        {
            if (userInput == "1" || userInput == "2" || userInput == "3")
            {
                return true;
            }

            Console.WriteLine("Proszę wybrać numer z listy");
            return false;
        }
    }
}
