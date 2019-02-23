@echo off
D:
cd \
cd workspace\TravelApp\TravelApp.Web.Admin

C:\Windows\System32\inetsrv\appcmd.exe stop site TravelApp
echo 停止iis站点....

rd /s /Q D:\workspace\TravelApp\TravelApp.Web.Admin\bin\Debug\netcoreapp2.2\publish
echo 清除原发布目录文件

echo TravelApp.Web.Admin 开始发布
echo ---------------------------------------
dotnet publish  TravelApp.Web.Admin.csproj -f netcoreapp2.2 -c Debug -o D:\workspace\TravelApp\TravelApp.Web.Admin\bin\Debug\netcoreapp2.2\publish -r win-x64 --self-contained false
echo ---------------------------------------

C:\Windows\System32\inetsrv\appcmd.exe start site TravelApp
echo 启动iis站点....

echo TravelApp.Web.Admin 发布完毕
set /p input=