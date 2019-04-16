FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Dragon6 Core/Dragon6 Core.csproj", "Dragon6 Core/"]
RUN dotnet restore "Dragon6 Core/Dragon6 Core.csproj"
COPY . .
WORKDIR "/src/Dragon6 Core"
RUN dotnet build "Dragon6 Core.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Dragon6 Core.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS=http://*:$PORT
ENTRYPOINT ["dotnet", "--no-launch-profile", "Dragon6 Core.dll"]