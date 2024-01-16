FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Frontent/WebUI/WebUI.csproj", "Frontent/WebUI/"]
COPY ["Frontent/DtoLayer/DtoLayer.csproj", "Frontent/DtoLayer/"]
COPY ["Frontent/BusinessLayer/BusinessLayer.csproj", "Frontent/BusinessLayer/"]
RUN dotnet restore "Frontent/WebUI/WebUI.csproj"
COPY . .
WORKDIR "/src/Frontent/WebUI"
RUN dotnet build "WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebUI.dll"]
