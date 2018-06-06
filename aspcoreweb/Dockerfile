FROM microsoft/aspnetcore:2.0
WORKDIR /app
EXPOSE 80
COPY obj/Docker/publish/aspcoreweb ./
ENTRYPOINT ["dotnet", "AspCoreWeb.dll"]
