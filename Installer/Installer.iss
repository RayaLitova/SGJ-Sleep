; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "I had a bad dream"
#define MyAppVersion "0.1"
#define MyAppPublisher "75% TUES"
#define MyAppURL "https://7ahk4et0.itch.io/i-had-a-bad-dream"
#define MyAppExeName "Sleep.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{E7BFB98C-2315-44AD-ACCB-7F1BE2326CB4}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=K:\Unity\SGJ-Sleep\Installer
OutputBaseFilename=IHadABadDreamSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "bulgarian"; MessagesFile: "compiler:Languages\Bulgarian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "K:\Unity\SGJ-Sleep\Build\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "K:\Unity\SGJ-Sleep\Build\UnityPlayer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "K:\Unity\SGJ-Sleep\Build\Sleep_Data\*"; DestDir: "{app}\Sleep_Data"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "K:\Unity\SGJ-Sleep\Build\MonoBleedingEdge\*"; DestDir: "{app}\MonoBleedingEdge"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

