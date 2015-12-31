; -- PutItOnCB_Setup.iss --
; -- (Taken from Example1.iss ) --
; Demonstrates copying 3 files and creating an icon.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!

[Setup]
AppName=PutItOnCB
AppVersion=1.3
DefaultDirName={pf}\PutItOnCB
DefaultGroupName=PutItOnCB
;UninstallDisplayIcon={app}\PutItOnCB.exe
SourceDir="..\bin\Release"
; If you set 'SourceDir', you must force 'OutputDir' to be where you want it.
OutputDir="..\..\Setup\Output"
OutputBaseFilename="PutItOnCB_Setup"

[Files]
Source: "PutItOnCB.exe"; DestDir: "{app}"
Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme

[Icons]
; (NO shortcuts are created by default. You need this.)
Name: "{userdesktop}\PutItOnCB"; Filename: "{app}\PutItOnCB.exe"; Tasks: "desktopicon"; Comment: "Put text on clipboard."
Name: "{group}\PutItOnCB"; Filename: "{app}\PutItOnCB.exe"; Comment: "Put text on clipboard."
;Name: "{group}\PutItOnCB"; Filename: "{app}\PutItOnCB.exe"
Name: "{group}\Uninstall PutItOnCB"; Filename: "{uninstallexe}"
;Name: "{group}\View HowSlowIsASPS Log"; Filename: "{userappdata}\HowSlowIsASPSlog.txt"

; Tasks section - Defines user-customizable tasks
[Tasks]
Name: "desktopicon"; Description: "Create a desktop icon"

; Run section
[Run]
;Filename: "{app}\PutItOnCB.exe.config"; Flags: shellexec postinstall; Description: "Edit config file."

; End of Script