FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Directory.Build.props ./
COPY ["Wimm.Api/Wimm.Api.csproj", "Wimm.Api/"]
RUN dotnet restore "Wimm.Api/Wimm.Api.csproj"
COPY . .
WORKDIR "/src/Wimm.Api"
RUN dotnet build "Wimm.Api.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/Wimm.Api"
RUN dotnet publish "Wimm.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wimm.Api.dll"]