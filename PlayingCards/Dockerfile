FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PlayingCards/PlayingCards.csproj", "PlayingCards/"]
RUN dotnet restore "PlayingCards/PlayingCards.csproj"
COPY . .
WORKDIR "/src/PlayingCards"
RUN dotnet build "PlayingCards.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlayingCards.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlayingCards.dll"]
