# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY dosLogistic.API.csproj .
RUN dotnet restore dosLogistic.API.csproj

# Copy the remaining source code and build the application
COPY . .
RUN dotnet build dosLogistic.API.csproj -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish dosLogistic.API.csproj -c Release -o /app/publish

# Stage 3: Final
FROM mcr.microsoft.com/dotnet/aspnet:7.0  AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy the published output from the previous stage
COPY --from=publish /app/publish .

# Copy the appsettings files
COPY appsettings.json .
COPY appsettings.Development.json .

# Set the entry point for running the application
ENTRYPOINT ["dotnet", "dosLogistic.API.dll", "--urls=http://0.0.0.0:5555"]
