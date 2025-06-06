[Setup]
AppName=Cheque Printer Service
AppVersion=1.0
DefaultDirName={pf}\ChequePrinterService
DefaultGroupName=Cheque Printer Service
OutputDir=.\Output
OutputBaseFilename=ChequePrinterInstaller
Compression=lzma
SolidCompression=yes

[Files]
Source: "ChequePrinterService.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "ChequePrinterService.exe.config"; DestDir: "{app}"; Flags: ignoreversion

[Run]
Filename: "sc.exe"; Parameters: "create ""ChequePrinterService"" binPath= ""{app}\ChequePrinterService.exe"" start= auto DisplayName= ""Cheque Printer Windows Service"""; StatusMsg: "Installing Windows Service..."; Flags: runhidden runascurrentuser
Filename: "sc.exe"; Parameters: "start ChequePrinterService"; StatusMsg: "Starting Service..."; Flags: runhidden runascurrentuser

[UninstallRun]
Filename: "sc.exe"; Parameters: "stop ChequePrinterService"; Flags: runhidden runascurrentuser
Filename: "sc.exe"; Parameters: "delete ChequePrinterService"; Flags: runhidden runascurrentuser

[Icons]
Name: "{group}\Uninstall Cheque Printer Service"; Filename: "{uninstallexe}"
