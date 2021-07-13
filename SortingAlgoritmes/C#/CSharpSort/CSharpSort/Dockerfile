FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CSharpSort/CSharpSort.csproj", "CSharpSort/"]
RUN dotnet restore "CSharpSort/CSharpSort.csproj"
COPY . .
WORKDIR "/src/CSharpSort"
RUN dotnet build "CSharpSort.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpSort.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpSort.dll"]
