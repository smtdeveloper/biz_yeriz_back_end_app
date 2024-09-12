#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/bizYeriz.WebApi/bizYeriz.WebApi.csproj", "src/Presentation/bizYeriz.WebApi/"]
COPY ["src/Infrastructure/bizYeriz.Persistence/bizYeriz.Persistence.csproj", "src/Infrastructure/bizYeriz.Persistence/"]
COPY ["src/Core/bizyeriz.Application/bizyeriz.Application.csproj", "src/Core/bizyeriz.Application/"]
COPY ["src/Core/bizYeriz.Domain/bizYeriz.Domain.csproj", "src/Core/bizYeriz.Domain/"]
RUN dotnet restore "./src/Presentation/bizYeriz.WebApi/bizYeriz.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Presentation/bizYeriz.WebApi"
RUN dotnet build "./bizYeriz.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./bizYeriz.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bizYeriz.WebApi.dll"]