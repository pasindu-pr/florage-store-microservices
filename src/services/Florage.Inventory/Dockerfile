#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./src/services/Florage.Inventory/Florage.Inventory.csproj", "."]
RUN dotnet nuget add source "https://nuget.pkg.github.com/PasinduPrabhashitha/index.json" --name "githubfeed" --username "PasinduPrabhashitha" --password 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 --store-password-in-clear-text
RUN dotnet restore "./Florage.Inventory.csproj"
COPY ./src/services/Florage.Inventory/. .
WORKDIR "/src/."
RUN dotnet build "Florage.Inventory.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Florage.Inventory.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Florage.Inventory.dll"]