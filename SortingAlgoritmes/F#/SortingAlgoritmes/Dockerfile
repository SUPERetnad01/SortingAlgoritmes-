FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SortingAlgoritmes/SortingAlgoritmes.fsproj", "SortingAlgoritmes/"]
RUN dotnet restore "SortingAlgoritmes/SortingAlgoritmes.fsproj"
COPY . .
WORKDIR "/src/SortingAlgoritmes"
RUN dotnet build "SortingAlgoritmes.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SortingAlgoritmes.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SortingAlgoritmes.dll"]
