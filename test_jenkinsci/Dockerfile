#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["test_jenkinsci/test_jenkinsci.csproj", "test_jenkinsci/"]
RUN dotnet restore "test_jenkinsci/test_jenkinsci.csproj"
COPY . .
WORKDIR "/src/test_jenkinsci"
RUN dotnet build "test_jenkinsci.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "test_jenkinsci.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test_jenkinsci.dll"]