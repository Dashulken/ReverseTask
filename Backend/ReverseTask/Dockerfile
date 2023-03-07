#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ReverseTask/ReverseTask.csproj", "ReverseTask/"]
RUN dotnet restore "ReverseTask/ReverseTask.csproj"
COPY . .
WORKDIR "/src/ReverseTask"
RUN dotnet build "ReverseTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReverseTask.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:5001;http://*:5000 ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "ReverseTask.dll"]