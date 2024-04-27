FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 10080
EXPOSE 10443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["YARP-Gateway/YARP-Gateway.csproj", "YARP-Gateway/"]
RUN dotnet restore "YARP-Gateway/YARP-Gateway.csproj"
COPY . .
WORKDIR "/src/YARP-Gateway"
RUN dotnet build "YARP-Gateway.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "YARP-Gateway.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false
WORKDIR /app
COPY ./YARP-Gateway/Certificate/localhost.pfx /app/publish/Certificate/localhost.pfx

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YARP-Gateway.dll"]