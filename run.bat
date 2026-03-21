@echo off
echo Đang khởi động SmartRecruit API...
start "SmartRecruit API" cmd /k "dotnet run --project SmartRecruit.API/SmartRecruit.API.csproj --launch-profile https"

echo Đang khởi động SmartRecruit WebPortal...
start "SmartRecruit WebPortal" cmd /k "dotnet run --project SmartRecruit.WebPortal/SmartRecruit.WebPortal.csproj --launch-profile https"

echo Các dự án đang khởi động. Bạn có thể đóng cửa sổ này.
