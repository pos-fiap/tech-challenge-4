FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TechChallenge4.Api/TechChallenge4.Api.csproj", "TechChallenge4.Api/"]
RUN dotnet restore "./TechChallenge4.Api/./TechChallenge4.Api.csproj"
COPY . .
WORKDIR "/src/TechChallenge4.Api"
RUN dotnet build "./TechChallenge4.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TechChallenge4.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechChallenge4.Api.dll"]