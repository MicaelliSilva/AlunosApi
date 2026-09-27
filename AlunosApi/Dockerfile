# 1. Imagem base do .NET SDK para compilar o código
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo .csproj e restaura as dependências
COPY ["AlunosApi.csproj", "./"]
RUN dotnet restore "AlunosApi.csproj"

# Copia todo o restante do código e realiza a compilação/publish
COPY . .
RUN dotnet publish "AlunosApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 2. Imagem base do .NET ASPNET Runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Define a porta padrão do ASP.NET Core dentro do container
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "AlunosApi.dll"]