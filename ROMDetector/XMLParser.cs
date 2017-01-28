// Made by: Aukie's Homebrew.
// 28-01-2017

using System.Xml.Linq;
using System.Collections.Generic;

namespace ROMDetector
{
    class XMLParser
    {
        private XDocument romfile;

        public XMLParser()
        {
            romfile = XDocument.Load("roms.xml");    
        }

        ~XMLParser()
        {

        }

        public string GetNameFromCode(string gamecode)
        {
            
            XElement root = romfile.Element("games"); // Get the root element.

            IEnumerable <XElement> game = root.Descendants("game"); // Get all 'game' elements in the root element
            string ret = "";


           
            foreach (XElement i in game)

            {
                if (i.Attribute("code").Value == gamecode) // if the code is equal to the parameter.
                {
                    ret = i.Attribute("name").Value;
                    break;
                }
                else
                {
                    continue;
                }
   
            }
           return ret;
       }
      
    }
}
