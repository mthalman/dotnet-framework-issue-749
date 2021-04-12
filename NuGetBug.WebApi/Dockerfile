#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

ARG FEED_USERNAME
ARG FEED_ACCESSTOKEN
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS \
    "{\"endpointCredentials\": [{\"endpoint\":\"https://gandalan.pkgs.visualstudio.com/_packaging/private_test_repo/nuget/v3/index.json\", \"username\":\"${FEED_USERNAME}\", \"password\":\"${FEED_ACCESSTOKEN}\"}]}"

# Credential Provider: https://github.com/Microsoft/artifacts-credprovider
RUN curl -L https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash

#COPY ["NuGetBug.WebApi/NuGetBug.WebApi.csproj", "NuGetBug.WebApi/"]
COPY . .
RUN dotnet restore "NuGetBug.WebApi/NuGetBug.WebApi.csproj"
#COPY . .
WORKDIR "/src/NuGetBug.WebApi"
# We don't use build
#RUN dotnet build "NuGetBug.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NuGetBug.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NuGetBug.WebApi.dll"]