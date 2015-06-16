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
        private static string errMessage = "";

        [STAThread]
        static void Main(string[] args)
        {
            bool success = false;
            Console.WriteLine("PutItOnCB Ver. 1.2 - Wednesday, January 21, 2015 - Jeff Nygren");

            // WorkAround for CLIPBRD_E_CANT_OPEN exception
            for (int i = 0; i < 10; i++)
            {
                if (success = TrySetText(CBText))
                    break;
                System.Threading.Thread.Sleep(300);
            }

            if (!success)
            {
                // Display exception message, wait for keypress.
                Console.Write("\n{0}  Press any key to continue...", errMessage); Console.ReadKey();
            }

#if AUDIBLE
            System.Media.SystemSounds.Beep.Play();  // Indicate that program ran.
#endif

#if PROMPTFORCLOSE
            Console.Write("\nPress any key to exit..."); Console.ReadKey();
#endif
        }


        /// <summary>
        /// Clipboard.SetText with exception handling
        /// </summary>
        /// <param name="text"></param>
        /// <returns>success or failure</returns>
        private static bool TrySetText(string text)
        {
            bool result = true;

            try
            {
                Clipboard.SetText(CBText);  // Put text on ClipBoard
            }
            catch (Exception ex)
            {
                // Save exception message.
                errMessage = ex.Message;
                result = false;
            }

            return result;
        }


        // Properties
        private static string CBText {
            get { return cbText; }
            set { cbText = value; }
        }
    }
}