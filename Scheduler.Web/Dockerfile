FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Scheduler.Web/Scheduler.Web.csproj", "Scheduler.Web/"]
RUN dotnet restore "Scheduler.Web/Scheduler.Web.csproj"
COPY . .
WORKDIR "/src/Scheduler.Web"
RUN dotnet build "Scheduler.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scheduler.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scheduler.Web.dll"]
