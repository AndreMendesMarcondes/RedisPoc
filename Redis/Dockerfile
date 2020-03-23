FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Redis.csproj", "./"]
RUN dotnet restore "./Redis.csproj"
COPY . .
RUN dotnet build "Redis.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Redis.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Redis.dll"]