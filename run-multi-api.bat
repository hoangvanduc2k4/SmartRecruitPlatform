@echo off
echo Đang khởi động SmartRecruit API - Instance 1 (Port 5064 / 7001)...
start "SmartRecruit API - Instance 1" cmd /k "dotnet run --project SmartRecruit.API/SmartRecruit.API.csproj --launch-profile https"

echo Đang khởi động SmartRecruit API - Instance 2 (Port 5065 / 7002)...
start "SmartRecruit API - Instance 2" cmd /k "dotnet run --project SmartRecruit.API/SmartRecruit.API.csproj --urls ""https://localhost:7002;http://localhost:5065"""

echo Đang khởi động SmartRecruit WebPortal...
start "SmartRecruit WebPortal" cmd /k "dotnet run --project SmartRecruit.WebPortal/SmartRecruit.WebPortal.csproj --launch-profile https"

echo.
echo Các dự án đang được khởi chạy trong các cửa sổ riêng biệt.
echo Bạn có thể truy cập qua Nginx Load Balancer tại địa chỉ: http://localhost:8000
echo.
