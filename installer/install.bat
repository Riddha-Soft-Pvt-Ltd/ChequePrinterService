@echo off
echo Installing ChequePrinterService...

:: Install the service
sc create "ChequePrinterService" binPath= "%~dp0ChequePrinterService.exe" start= auto DisplayName= "Cheque Printer Windows Service"

:: Start the service
sc start ChequePrinterService

pause
