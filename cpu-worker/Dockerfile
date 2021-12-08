FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR "/cpu-worker"
COPY ["cpu-worker.csproj", "cpu-worker/"]
RUN dotnet restore "cpu-worker/cpu-worker.csproj"
COPY . .
WORKDIR "/cpu-worker"
RUN dotnet build "cpu-worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cpu-worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cpu-worker.dll"]
