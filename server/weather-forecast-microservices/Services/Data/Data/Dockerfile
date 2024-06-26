#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Data/Data/Data.csproj", "Services/Data/Data/"]
COPY ["RabbitMQ/RabbitMQ/RabbitMQ.csproj", "RabbitMQ/RabbitMQ/"]
RUN dotnet restore "./Services/Data/Data/Data.csproj"
COPY . .
WORKDIR "/src/Services/Data/Data"
RUN dotnet build "./Data.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Data.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Data.dll"]