FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Backend/WebApi/WebApi.csproj", "Backend/WebApi/"]
COPY ["Backend/BusinessLayer/BusinessLayer.csproj", "Backend/BusinessLayer/"]
COPY ["Backend/DataAccessLayer/DataAccessLayer.csproj", "Backend/DataAccessLayer/"]
COPY ["Backend/EntityLayer/EntityLayer.csproj", "Backend/EntityLayer/"]
COPY ["Backend/DtoLayer/DtoLayer.csproj", "Backend/DtoLayer/"]
RUN dotnet restore "Backend/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/Backend/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
