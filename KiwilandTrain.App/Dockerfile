FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KiwilandTrain.App/KiwilandTrain.App.csproj", "KiwilandTrain.App/"]
RUN dotnet restore "KiwilandTrain.App/KiwilandTrain.App.csproj"
COPY . .
WORKDIR "/src/KiwilandTrain.App"
RUN dotnet build "KiwilandTrain.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KiwilandTrain.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KiwilandTrain.App.dll"]
