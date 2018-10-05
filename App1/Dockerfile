FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53952
EXPOSE 44340

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY App1/App1.csproj App1/
RUN dotnet restore App1/App1.csproj
COPY . .
WORKDIR /src/App1
RUN dotnet build App1.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish App1.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "App1.dll"]
