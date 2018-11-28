using System;
using System.IO;
using System.Text;

namespace Notatnik_parser.Notepad
{
    public class NotepadMenu
    {    
        string pathInstructions = "Podaj pełną ścieżkę z nazwą pliku lub samą nazwę pliku z rozszerzeniem, żeby {0} domyślnego folderu:";
        
        public void Run() {

            ShowNotpadMenu();
            MenageUserInput();
        }

        public void ShowNotpadMenu()
        {
            Console.WriteLine("Witamy w notatniku. Wybierz:");
            Console.WriteLine("1 - nowa notatka");
            Console.WriteLine("2 - otwórz notatkę");
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
            if (userInput == "1" || userInput == "2")
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
                    WriteNewNote();
                    break;
                case "2":
                    OpenTextFile();
                    break;
                default:
                    Console.WriteLine("Błąd");
                    break;
            }
        }

        private void WriteNewNote()
        {       
            Console.WriteLine("Wprowadź notatkę (wciśnij 2 x <enter> aby zapisać):");
            string note = Console.ReadLine();

            ConsoleKeyInfo typedKey = Console.ReadKey();

            if (typedKey.Key == ConsoleKey.Enter)
            {                
                SaveFile(note);                
            }
            else
            {                
                Console.WriteLine("Błąd. Nie udało się zapisać.");                                
            }

            ReturnToMenu();
        }

        private void SaveFile(string textNoteParameter)
        {    
            Console.WriteLine(pathInstructions, "zapisać do");
            string insertPathValue = MenageUserPathInput();
            string pathAndfileName = MenageUserNameInput(insertPathValue);
            
            try
            {
                using (FileStream fs = File.Create(pathAndfileName))
                {
                    Byte[] textNote = new UTF8Encoding(true).GetBytes(textNoteParameter);
                    fs.Write(textNote, 0, textNote.Length);
                }
                Console.WriteLine("Zapisano.");                
            }
            catch(UnauthorizedAccessException)
            {
                Console.WriteLine("Nie masz uprawnień do folderu.");
            }
        }

        private bool IsUserPathInputValid(string insertPathValue)
        {
            if(Directory.Exists(insertPathValue))
            {                
                return true;
            }               
            else 
            {
                Console.WriteLine("{0} - błąd: folder nie istnieje, albo nie masz do niego dostępu.", insertPathValue);
                return false;
            }      
        }

        private string MenageUserPathInput()
        {
            string insertPathValue;

            do
            {   
                Console.WriteLine("Wpisz ścieżkę do folderu:");                
                insertPathValue = Console.ReadLine();                
            }
            while (!IsUserPathInputValid(insertPathValue));

            return insertPathValue;
        }

        private string MenageUserNameInput(string pathName)
        {
            string insertNameValue;
            string insertPathAndNameValue;

            do
            {   
                Console.WriteLine("Podaj nazwę pliku z rozszerzeniem:");                
                insertNameValue = Console.ReadLine();
                insertPathAndNameValue = pathName + '/' + insertNameValue;
            }
            while (!IsFileExist(insertPathAndNameValue));

            return insertPathAndNameValue;
        }

        private bool IsFileExist(string insertPathAndNameValue)
        {
            if(File.Exists(insertPathAndNameValue))
            {                
                Console.WriteLine("{0} - ta ścieżka jest niewłaściwa.", insertPathAndNameValue);
                return false;
            }               
            else 
            {
                return true;
            }      
        }

        private void OpenTextFile()
        {   
            string insertPathValue = MenageUserPathAndNameInput();
            Console.WriteLine("Treść otworzonej notatki:");

            using (FileStream fs = File.Open(insertPathValue, FileMode.Open)) 
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b,0,b.Length) > 0) 
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }

            ReturnToMenu();
        }

        private bool IsUserPathAndNameInputValid(string insertPathAndNameValue)
        {
            if(File.Exists(insertPathAndNameValue))
            {                
                return true;
            }               
            else 
            {
                Console.WriteLine("{0} - ta ścieżka jest niewłaściwa.", insertPathAndNameValue);
                return false;
            }      
        }
        
        private string MenageUserPathAndNameInput()
        {
            string insertPathAndNameValue;

            do
            {   
                Console.WriteLine(pathInstructions, "otworzyć z");                
                insertPathAndNameValue = Console.ReadLine();                
            }
            while (!IsUserPathAndNameInputValid(insertPathAndNameValue));

            return insertPathAndNameValue;
        }

        private void ReturnToMenu()
        {
            var mainMenu = new Notatnik_parser.MainMenu.MainMenu();
                mainMenu.Run();
        }
    }
}
