FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/bizYeriz.WebApi/bizYeriz.WebApi.csproj", "src/Presentation/bizYeriz.WebApi/"]
COPY ["src/Infrastructure/bizYeriz.Persistence/bizYeriz.Persistence.csproj", "src/Infrastructure/bizYeriz.Persistence/"]
COPY ["src/Core/bizyeriz.Application/bizyeriz.Application.csproj", "src/Core/bizyeriz.Application/"]
COPY ["src/Core/bizYeriz.Domain/bizYeriz.Domain.csproj", "src/Core/bizYeriz.Domain/"]
COPY ["src/Shared/bizYeriz.Shared/bizYeriz.Shared.csproj", "src/Shared/bizYeriz.Shared/"]
RUN dotnet restore "src/Presentation/bizYeriz.WebApi/bizYeriz.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Presentation/bizYeriz.WebApi"
RUN dotnet build "bizYeriz.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "bizYeriz.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 8080