; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "SPK AHP"
#define MyAppVersion "1.0"
#define MyAppPublisher "wirasakti"
#define MyAppURL "http://www.wirasakti.web.id"
#define MyAppExeName "SPK - AHP.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{1B768106-C6AC-4BE9-8249-FBAE165F53E7}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableDirPage=yes
DefaultGroupName={#MyAppName}
OutputDir=D:\Code\NET\spk-ahp-vb.net-master\Program\spk\output
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\SPK - AHP.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\AxShockwaveFlashObjects.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\BouncyCastle.Crypto.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.CrystalReports.Engine.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.ClientDoc.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.CommLayer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.CommonControls.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.CommonObjectModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.Controllers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.CubeDefModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.DataDefModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.DataSetConversion.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.ObjectFactory.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.Prompting.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.ReportDefModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportAppServer.XmlSerialize.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.ReportSource.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.Shared.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\CrystalDecisions.Windows.Forms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\Google.Protobuf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\Google.Protobuf.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\MySql.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\MySql.Data.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\Renci.SshNet.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\Renci.SshNet.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\ShockwaveFlashObjects.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\SPK - AHP.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\SPK - AHP.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\SPK - AHP.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\SPK - AHP.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\NET\spk-ahp-vb.net-master\Program\spk\spk\bin\Release\stdole.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, "&", "&&")}}"; Flags: nowait postinstall skipifsilent

