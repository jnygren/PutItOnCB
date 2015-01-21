// Preprocessor symbols must be defined before the first token in the file.
#define AUDIBLE
//#define PROMPTFORCLOSE

// Namespaces
using System;
using System.Windows;   // For Clipboard class. (Add reference to PresentationCore.)

namespace PutItOnCB
{
    class Program
    {
        private static string cbText = "Tlhfckoctbcr$1955#170&Sex";

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("PutItOnCB Ver. 1.1 - Friday, June 28, 2013 - Jeff Nygren");

            try
            {
                Clipboard.SetText(CBText);  // Put text on ClipBoard
            }
            catch (Exception ex)
            {
                Console.Write("\n{0}  Press any key to continue...", ex.Message); Console.ReadKey();
            }

#if AUDIBLE
            System.Media.SystemSounds.Beep.Play();  // Indicate that program ran.
#endif

#if PROMPTFORCLOSE
            Console.Write("\nPress any key to exit..."); Console.ReadKey();
#endif
        }

        private static string CBText {
            get { return cbText; }
            set { cbText = value; }
        }
    }
}