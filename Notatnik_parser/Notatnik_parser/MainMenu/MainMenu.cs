using Notatnik_parser.Notepad;
using Notatnik_parser.Xml.Creator;
using Notatnik_parser.Xml.Parser;
using System;

namespace Notatnik_parser.MainMenu
{
    public class MainMenu
    {
        public void Run()
        {
            ShowInitInfo();
            MenageUserInput();

            Console.ReadKey();
        }

        public void ShowInitInfo()
        {
            Console.WriteLine("Witaj w aplikacji Notatnik/Parser");
            Console.WriteLine("Wybierz co chcesz robić:");
            Console.WriteLine("1 - notatnik");
            Console.WriteLine("2 - parser XML");
            Console.WriteLine("3 - kreator XML");
        }

        private void MenageUserInput()
        {
            string insertValue;
            do
            {
                insertValue = Console.ReadLine();

            } while (!IsUserInputValid(insertValue));

            GoToUserChoice(insertValue);
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

        private void GoToUserChoice(string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    new NotepadMenu().Run();
                    break;
                case "2":
                    new XmlParserMenu().Run();
                    break;
                case "3":
                    new XmlCreatorMenu().Run();
                    break;
                default:
                    Console.WriteLine("Błąd");
                    break;
            }
        }
    }
}
