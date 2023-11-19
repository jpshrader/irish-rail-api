#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["irish-rail-api/irish-rail-api.csproj", "irish-rail-api/"]
RUN dotnet restore "irish-rail-api/irish-rail-api.csproj"
COPY . .
WORKDIR "/src/irish-rail-api"
RUN dotnet build "irish-rail-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "irish-rail-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "irish-rail-api.dll"]