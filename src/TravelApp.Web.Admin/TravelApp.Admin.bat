@echo off
D:
cd \
cd workspace\TravelApp\TravelApp.Web.Admin

C:\Windows\System32\inetsrv\appcmd.exe stop site TravelApp
echo ֹͣiisվ��....

rd /s /Q D:\workspace\TravelApp\TravelApp.Web.Admin\bin\Debug\netcoreapp2.2\publish
echo ���ԭ����Ŀ¼�ļ�

echo TravelApp.Web.Admin ��ʼ����
echo ---------------------------------------
dotnet publish  TravelApp.Web.Admin.csproj -f netcoreapp2.2 -c Debug -o D:\workspace\TravelApp\TravelApp.Web.Admin\bin\Debug\netcoreapp2.2\publish -r win-x64 --self-contained false
echo ---------------------------------------

C:\Windows\System32\inetsrv\appcmd.exe start site TravelApp
echo ����iisվ��....

echo TravelApp.Web.Admin �������
set /p input=