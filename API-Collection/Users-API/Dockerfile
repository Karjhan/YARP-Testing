﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5080
EXPOSE 5443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Users-API/Users-API.csproj", "Users-API/"]
COPY ["Commons/Commons.csproj", "Commons/"]
RUN dotnet restore "Users-API/Users-API.csproj"
COPY . .
WORKDIR "/src/Users-API"
RUN dotnet build "Users-API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Users-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
WORKDIR /app
COPY ./Users-API/Certificate/localhost.pfx /app/publish/Certificate/localhost.pfx

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Users-API.dll"]
