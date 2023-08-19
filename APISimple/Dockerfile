#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APISimple/APISimple.csproj", "APISimple/"]
RUN dotnet restore "APISimple/APISimple.csproj"
COPY . .
WORKDIR "/src/APISimple"
RUN dotnet build "APISimple.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APISimple.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APISimple.dll"]