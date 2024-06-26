#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./API-Releases/API-Releases.csproj", "API-Releases/"]
COPY ["./Application/Application.csproj", "Application/"]
COPY ["./Domain/Domain.csproj", "Domain/"]
COPY ["./Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "API-Releases/API-Releases.csproj"
COPY . .
WORKDIR "/src/API-Releases"
RUN dotnet build "API-Releases.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
RUN dotnet publish "API-Releases.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API-Releases.dll"]