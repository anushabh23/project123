FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["AuthServer.csproj", "./"]
RUN dotnet restore "AuthServer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AuthServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthServer.dll"]

# docker run --name authcontainer -p 5000:80 -e "SQLSERVER_Auth"="Server=sqlserver; Database=UserDb; User Id=SA; Password=P@ssw0rd; Trusted_Connection=True; Integrated Security=False" niraj2998/authserver
# docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssw0rd" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu