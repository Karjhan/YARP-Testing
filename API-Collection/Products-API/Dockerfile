﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 6080
EXPOSE 6443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Products-API/Products-API.csproj", "Products-API/"]
COPY ["Commons/Commons.csproj", "Commons/"]
RUN dotnet restore "Products-API/Products-API.csproj"
COPY . .
WORKDIR "/src/Products-API"
RUN dotnet build "Products-API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Products-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
COPY ./Products-API/Certificate/localhost.pfx /app/publish/Certificate/localhost.pfx

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products-API.dll"]
