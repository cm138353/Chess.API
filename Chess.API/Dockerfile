FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .

RUN dotnet publish Chess.API/Chess.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:10000

COPY --from=build /app/publish .

ENTRYPOINT ["/bin/sh", "-c", "dotnet Chess.API.dll --migrate-database && exec dotnet Chess.API.dll"]