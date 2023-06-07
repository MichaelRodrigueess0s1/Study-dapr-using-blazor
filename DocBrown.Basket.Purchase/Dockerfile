#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DocBrown.Basket.Purchase/DocBrown.Basket.Purchase.csproj", "DocBrown.Basket.Purchase/"]
COPY ["DocBrown.Domain/DocBrown.Domain.csproj", "DocBrown.Domain/"]
RUN dotnet restore "DocBrown.Basket.Purchase/DocBrown.Basket.Purchase.csproj"
COPY . .
WORKDIR "/src/DocBrown.Basket.Purchase"
RUN dotnet build "DocBrown.Basket.Purchase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocBrown.Basket.Purchase.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocBrown.Basket.Purchase.dll"]