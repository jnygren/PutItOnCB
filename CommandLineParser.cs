using System;
using System.Linq;

/*****************************************************************************\
*  To define 'Properties', right-click the project in Solution Explorer and   *
*  select 'Properties'. Go to the 'Settings panel. If this is the first time, *
*  you will be prompted "... Click here if you would like to create one."     *
*  Click the link. This will create 'Settings.settings' in the Properties     *
*  folder. Click the link. then define the properties you need.               *
\*****************************************************************************/

namespace PutItOnCB
{
    class CommandLineParser
    {
        #region Help Screen
        private static string[] helpPage = new string[] { 
            "===============================================================================", 
            "\tHELP", 
            "", 
            "Normally you will just run the program, with no command line arguments. ",
            "This will put the stored text on the clipboard, ready to paste where ever you ",
            "need it.",
            "", 
            "Command line arguments are used ONLY to configure the program. Nothing is put ",
            "on the clipboard when any command line argument is specified.", 
            "", 
            "Usage: PutItOnCB [/?][/H][/B][/S][/P][/Q][/V][/C][/T [\"text\"]]", 
            "/?, /H(elp) - Display this 'Help' screen.", 
            "/B(eep) - Privide audible indication at program exit.", 
            "/S(ilent) - Turn off the audible, program exit indication.", 
            "/P(rompt) - Prompt to 'Press any key' before closing the program window.", 
            "/Q(uiet) - No prompt is used.", 
            "/V(iew) - View the current configuration settings.", 
            "/C(onfig) - Display a GUI configuration screen.", 
            "/T(ext) [text string] - Set the text to be placed on the clipboard. If text ",
            "contains spaces, enclose it in quotation marks. If no text string is provided, ",
            "the stored text is cleared.", 
            "", 
            "Arguments may begin with either a dash '-' or a slash '/', are not case ",
            "sensitive, and may be shortened to just the first character. ", 
            "", 
            "===============================================================================", 
            " "
        };
        #endregion


        public static bool ParseCommandLine(string[] args)
        {
            bool settingsChanged = false;
            bool showHelp = false;
            bool showConfig = false;
            bool showView = false;
            string switchChars = "-/";                  // Valid arguments start with one of these chars

            for (int i = 0; i < args.Length; i++)
            {
                if (switchChars.Contains(args[i][0]))   // Must start with '-' or '/'
                {
                    args[i] = args[i].ToUpper();
                    switch (args[i][1])                 // Just look at first char. (/h is the same as -HELP)
                    {
                        case 'B':
                            Properties.Settings.Default.Audible = true;
                            settingsChanged = true;
                            break;

                        case 'C':
                            showConfig = true;
                            break;

                        case '?':
                        case 'H':
                            showHelp = true;
                            break;

                        case 'P':
                            Properties.Settings.Default.ClosePrompt = true;
                            settingsChanged = true;
                            break;

                        case 'Q':
                            Properties.Settings.Default.ClosePrompt = false;
                            settingsChanged = true;
                            break;

                        case 'S':
                            Properties.Settings.Default.Audible = false;
                            settingsChanged = true;
                            break;

                        case 'T':
                            Properties.Settings.Default.ClipBoardText = (i + 1 < args.Length) ? args[++i].Trim('\"') : "";
                            settingsChanged = true;
                            break;

                        case 'V':
                            showView = true;
                            break;

                        default:
                            Console.WriteLine(string.Format("\nInvalid command line argument [{0}].\n", args[i]));
                            return false;
                            //break;
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("\nInvalid command line argument [{0}].\n", args[i]));
                    return false;
                }
            }

            if (settingsChanged)
            {
                Properties.Settings.Default.Save();
                Console.WriteLine("Your settings have been saved.\n");
            }

            if (showHelp)
                Help();

            if (showConfig)
                Config();

            if (showView)
            {
                Console.WriteLine("");
                Console.WriteLine(string.Format("Audible 'program ended' indication = {0}.", Properties.Settings.Default.Audible));
                Console.WriteLine(string.Format("The 'text string' is [{0}].", Properties.Settings.Default.ClipBoardText));
                Console.WriteLine(string.Format("Prompt for Close = {0}.", Properties.Settings.Default.ClosePrompt));
                Console.WriteLine("\n");
            }

            if (settingsChanged && !Properties.Settings.Default.ClosePrompt)
            {   // Force prompt so user can see 'Saved' message.
                Console.Write("\n\tPress any key to close... "); Console.ReadKey(); Console.WriteLine("\n\n");
            }

            return (args.Length == 0) && !showConfig && !showHelp && !settingsChanged;
        }


        static void Help()
        {
            foreach (string line in helpPage)
                Console.WriteLine(line);
        }


        static void Config()
        {
            System.Windows.Forms.MessageBox.Show("The GUI configuration screen has not yet been implemented.", "Config");
        }

    }
}
