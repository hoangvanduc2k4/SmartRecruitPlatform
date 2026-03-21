@echo off
echo Starting SmartRecruit API...
start "SmartRecruit API" cmd /k "dotnet run --project SmartRecruit.API/SmartRecruit.API.csproj --launch-profile https"

echo Starting SmartRecruit WebPortal...
start "SmartRecruit WebPortal" cmd /k "dotnet run --project SmartRecruit.WebPortal/SmartRecruit.WebPortal.csproj --launch-profile https"

echo Both projects are starting. You can close this window.
pause
