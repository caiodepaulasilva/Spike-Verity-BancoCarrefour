#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./API-Report/API-Report.csproj", "API-Report/"]
COPY ["./Application/Application.csproj", "Application/"]
COPY ["./Domain/Domain.csproj", "Domain/"]
COPY ["./Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "API-Report/API-Report.csproj"
COPY . .
WORKDIR "/src/API-Report"
RUN dotnet build "API-Report.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
RUN dotnet publish "API-Report.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API-Report.dll"]