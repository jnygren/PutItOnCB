// Namespaces
using System;
using System.Windows;   // For Clipboard class. (Add reference to PresentationCore.)

namespace PutItOnCB
{
    class Program
    {
        private static string errMessage = "";

        [STAThread]
        static void Main(string[] args)
        {
            bool success = false;
            Console.WriteLine("\tPutItOnCB Ver. 1.3 - June 16, 2015 - Jeff Nygren\n");

            if (CommandLineParser.ParseCommandLine(args))
            {
                // WorkAround for CLIPBRD_E_CANT_OPEN exception
                for (int i = 0; i < 10; i++)
                {
                    if (success = TrySetText(Properties.Settings.Default.ClipBoardText))
                        break;
                    System.Threading.Thread.Sleep(300);
                }

                if (!success)
                {
                    // Display exception message, wait for keypress.
                    Console.Write("\n{0}  Press any key to continue...", errMessage); Console.ReadKey();
                }
            }

            if (Properties.Settings.Default.Audible)
                System.Media.SystemSounds.Beep.Play();  // Indicate that program ran.

            if (Properties.Settings.Default.ClosePrompt)
            {
                Console.Write("\nPress any key to exit..."); Console.ReadKey();
            }
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
                Clipboard.SetText(text);  // Put text on ClipBoard
            }
            catch (Exception ex)
            {
                // Save exception message.
                errMessage = ex.Message;
                result = false;
            }

            return result;
        }

    }
}