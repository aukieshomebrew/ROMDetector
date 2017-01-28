// Made by: Aukie's Homebrew.
// 28-01-2017

using System.IO;
using System.Text;

namespace HBTDetector
{
    class ROMDetector
    {

        private BinaryReader stream;
        

        static int Main(string[] args)
        {
            if (args.Length > 1) // Only accepts 1 argument.
                return 1; 
            ROMDetector romdetector = new ROMDetector(); // Creates the romdetector object
            Logger log = new Logger(); // Creates the logger object.


            // Creates string variables.
            string gamecode = "";
            string gamename = "";

            if(!romdetector.openROM(args[0]))
            {
                log.Error("File not found!");
                return 1;
            }

            gamecode = romdetector.findGameCode();
            log.Success("Gamecode = " + gamecode);

            gamename = romdetector.findGameName(gamecode);
            if(gamename == "") // If XMLParser returns no game name.
            {
                log.Error("No known GBA game!");
            }
            else
            {
                log.Success("Gamename = " + gamename);
            }


            System.Console.ReadKey();
            
            return 0;
        }
        
        public bool openROM(string path)
        {
            if (!File.Exists(path)) // Check if the ROM exists.
            {
                return false;
            }
            stream = new BinaryReader(File.Open(path, FileMode.Open));
            return true;
        }

        public string findGameCode()
        {
            stream.BaseStream.Seek(0xAC, SeekOrigin.Begin);  // Go seek from 0xAC
            return Encoding.UTF8.GetString(stream.ReadBytes(4)); // Read the first 4 bytes and convert them to a UTF8 string.
        }

        public string findGameName(string code)
        {
            XMLParser file = new XMLParser();
            return file.GetNameFromCode(code);  // XML Parser returns a game name.
        }
        
    }
}
