Clear-Host
	
Write-Host "GET AUTOMATED OSCAM COMPILER SCRIPT FOR WINDOWS"
Write-Host
Write-Host "Downloading latest automated oscam compiler script for windows ... " -NoNewline

Remove-Item -Force (-join($PSScriptRoot,'Build-OScamForWindows.ps1')) -ErrorAction SilentlyContinue
Invoke-WebRequest -Uri 'https://raw.githubusercontent.com/h0ly0ne/Build-OSCamForWindows/refs/heads/main/Build-OSCamForWindows.ps1' -OutFile (-join($PSScriptRoot,'\Build-OScamForWindows.ps1')) -UseBasicParsing

Write-Host "Starting automated oscam compiler script for windows ... " -NoNewline
& "$PSScriptRoot\Build-OScamForWindows.ps1"
Write-Host "done."