using System;
using System.IO;

namespace Notatnik_parser.Notepad
{
    public class NotepadMenu
    {
        public void SaveFile()
        {            
            string fileName = "LastNote.txt";            
            using (System.IO.FileStream fs = System.IO.File.Create(fileName))
            {

            }
        }
        public void Run()
        {
            Console.WriteLine("Witamy w notatniku");        
        }      
    }
}
