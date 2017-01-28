// Made by: Aukie's Homebrew.
// 28-01-2017

using System;

namespace ROMDetector
{
    class Logger
    {
        static Logger()
        {
            
        }

        public void Warning(string msg)
        {
            Console.WriteLine("[!] " + msg);
        }

        public void Information(string msg)
        {
            Console.WriteLine("[*] " + msg);
        }

        public void Error(string msg)
        {
            Console.WriteLine("[!!] " + msg);
        }

        public void Success(string msg)
        {
            Console.WriteLine("[+] " + msg);
        }
    }
}
