Docker
Docker+SQL
docker pull mcr.microsoft.com/mssql/server:2019-latest

docker run -d --name sql_server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=user123!' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
docker run --name sql_2019 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=user123!" -e "MSSQL_PID=Enterprise" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
docker exec -it sql_2019 /opt/mssql-tools/bin/sqlcmd -S localhost -U sa

docker exec sql-win cmd.exe /C "sqlcmd -U sa -S localhost -P 1Secure*Password1 -i c:\data\query.txt"







VS
dotnet tool install --global dotnet-ef
dotnet ef migrations add MyFirstMigration
dotnet ef database update
dotnet ef database update --context BloggingContext
