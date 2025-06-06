@echo off
echo Stopping and deleting ChequePrinterService...

sc stop ChequePrinterService
sc delete ChequePrinterService

pause
