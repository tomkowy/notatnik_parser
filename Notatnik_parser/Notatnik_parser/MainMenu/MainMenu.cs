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
        }
    }
}
