#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HoLGame.API/HoLGame.API.csproj", "HoLGame.API/"]
RUN dotnet restore "HoLGame.API/HoLGame.API.csproj"
COPY . .
WORKDIR "/src/HoLGame.API"
RUN dotnet build "HoLGame.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HoLGame.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HoLGame.API.dll"]