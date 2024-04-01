#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DataAccess.Example.WebApi/DataAccess.Example.WebApi.csproj", "DataAccess.Example.WebApi/"]
COPY ["DataAccess.Example.Core/DataAccess.Example.Core.csproj", "DataAccess.Example.Core/"]
COPY ["DataAccess.Example.EntityFramework/DataAccess.Example.EntityFramework.csproj", "DataAccess.Example.EntityFramework/"]
RUN dotnet restore "./DataAccess.Example.WebApi/DataAccess.Example.WebApi.csproj"
COPY . .
WORKDIR "/src/DataAccess.Example.WebApi"
RUN dotnet build "./DataAccess.Example.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DataAccess.Example.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataAccess.Example.WebApi.dll"]