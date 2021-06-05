# Wait to be sure that SQL Server came up
sleep 90s

# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 1Secure*Password1 -d master -i UserMicroserviceDB.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 1Secure*Password1 -d master -i PostMicroserviceDB.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 1Secure*Password1 -d master -i UserMicroserviceDBData.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 1Secure*Password1 -d master -i PostMicroserviceDBData.sql