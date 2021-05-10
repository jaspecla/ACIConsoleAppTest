FROM mcr.microsoft.com/dotnet/runtime:5.0

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "ACIConsoleAppTest.dll", "10", "/var/log/aci"]
