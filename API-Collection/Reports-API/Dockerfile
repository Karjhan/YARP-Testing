FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 7080
EXPOSE 7443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Reports-API/Reports-API.csproj", "Reports-API/"]
COPY ["Commons/Commons.csproj", "Commons/"]
RUN dotnet restore "Reports-API/Reports-API.csproj"
COPY . .
WORKDIR "/src/Reports-API"
RUN dotnet build "Reports-API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Reports-API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
COPY ./Reports-API/Certificate/localhost.pfx /app/publish/Certificate/localhost.pfx

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reports-API.dll"]
