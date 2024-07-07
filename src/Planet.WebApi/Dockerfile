#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Planet.WebApi/Planet.WebApi.csproj", "src/Planet.WebApi/"]
COPY ["src/Planet.Infrastructure/Planet.Infrastructure.csproj", "src/Planet.Infrastructure/"]
COPY ["src/Planet.Application/Planet.Application.csproj", "src/Planet.Application/"]
COPY ["src/Planet.Domain/Planet.Domain.csproj", "src/Planet.Domain/"]
COPY ["src/Planet.Persistence/Planet.Persistence.csproj", "src/Planet.Persistence/"]
RUN dotnet restore "./src/Planet.WebApi/Planet.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Planet.WebApi"
RUN dotnet build "./Planet.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Planet.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Planet.WebApi.dll"]