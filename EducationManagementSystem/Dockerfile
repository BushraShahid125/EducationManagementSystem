# Stage 1: Build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the code and publish
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 2: Run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the build output from Stage 1
COPY --from=build /app/out .

# Expose port (Render will assign a PORT)
EXPOSE 5000

# Start the app
ENTRYPOINT ["dotnet", "EducationManagementSystem.dll"]