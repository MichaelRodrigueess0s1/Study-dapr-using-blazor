#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DocBrown.App/Server/DocBrown.App.Server.csproj", "DocBrown.App/Server/"]
COPY ["DocBrown.App/Client/DocBrown.App.Client.csproj", "DocBrown.App/Client/"]
COPY ["DocBrown.Domain/DocBrown.Domain.csproj", "DocBrown.Domain/"]
COPY ["DocBrown.App/Shared/DocBrown.App.Shared.csproj", "DocBrown.App/Shared/"]
RUN dotnet restore "DocBrown.App/Server/DocBrown.App.Server.csproj"
COPY . .
WORKDIR "/src/DocBrown.App/Server"
RUN dotnet build "DocBrown.App.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocBrown.App.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocBrown.App.Server.dll"]