	PutItOnCB - ReadMe

"Put In On the ClipBoard" puts a fixed string on the system clipboard.

Normally you will just run the program, with no command line arguments.
This will put the stored text on the clipboard, ready to paste where ever you
need it.

Command line arguments are used ONLY to configure the program. Nothing is put
on the clipboard when any command line argument is specified.

Usage: PutItOnCB [/?][/H][/B][/S][/P][/Q][/V][/C][/T ["text"]]
/?, /H(elp) - Display 'Help' screen.
/B(eep) - Privide audible indication at program exit.
/S(ilent) - Turn off the audible, program exit indication.
/P(rompt) - Prompt to 'Press any key' before closing the program window.
/Q(uiet) - No prompt is used.
/V(iew) - View the current configuration settings.
/C(onfig) - Display a GUI configuration screen.
/T(ext) [text string] - Set the text to be placed on the clipboard. If text
contains spaces, enclose it in quotation marks. If no text string is provided,
the stored text is cleared.

Arguments may begin with either a dash '-' or a slash '/', are not case
sensitive, and may be shortened to just the first character.


================================================================================