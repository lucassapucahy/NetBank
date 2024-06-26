FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["NetBank.Users.API/NetBank.Users.API.csproj", "NetBank.Users.API/"]
COPY ["NetBank.Users.Domain/NetBank.Users.Domain.csproj", "NetBank.Users.Domain/"]
COPY ["NetBank.Users.Infra/NetBank.Users.Infra.csproj", "NetBank.Users.Infra/"]

RUN dotnet restore "NetBank.Users.API/NetBank.Users.API.csproj"

COPY . .
WORKDIR "/src/NetBank.Users.API"
RUN dotnet build "NetBank.Users.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetBank.Users.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetBank.Users.API.dll"]