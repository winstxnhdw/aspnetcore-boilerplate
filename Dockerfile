FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY *.csproj ./
COPY Scripts/ ./Scripts/
RUN dotnet publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/dist .
CMD ["dotnet", "Server"]
