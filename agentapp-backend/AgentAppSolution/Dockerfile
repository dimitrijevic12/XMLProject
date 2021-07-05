FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

VOLUME ["/wwwroot"]

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AgentApp.Api/AgentApp.Api.csproj", "AgentApp.Api/"]
COPY ["AgentApp.DataAccess/AgentApp.DataAccess.csproj", "AgentApp.DataAccess/"]
COPY ["AgentApp.Core/AgentApp.Core.csproj", "AgentApp.Core/"]
COPY . ./

RUN dotnet build "/src/AgentApp.Api/AgentApp.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "/src/AgentApp.Api/AgentApp.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AgentApp.Api.dll"]