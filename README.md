# Zenny Api

## what is Zenny?
We are an web aplication made whit the objectibe of facilitate and organize the personal budgets,this is only the Api, if you want to use our full aplication you will use : [Zenny App](https://github.com/MajoPino/Zenny-App-Front)



## Authors

- [@luisaferRP](https://www.github.com/luisaferRP)
- [@jtorova5](https://www.github.com/jtorova5)
- [@SanDaws](https://www.github.com/sanDaws)
- [@MajoPino](https://www.github.com/MajoPino)
- [@dfelipesr46](https://www.github.com/dfelipesr46)
- [@The-G-Man-Half-Life](https://www.github.com/The-G-Man-Half-Life)
## Zenny as project
### Why?
Most of the time when people try to get their personal  budgets done found themself in spreadsheets, doing codes, adjusting diagrams and wasting time. Whit this project we create a solution, this aplication will allow you to register all your income and outcome money and have a trazability of when and how much do you use your money.

## Packages

We use this packages:

[![Dotnet 8.0](https://img.shields.io/badge/SDK-Dotnet_8.0-green?logo=.NET)](https://dotnet.microsoft.com/es-es/)

[![Swagger](https://img.shields.io/badge/Packeage-Swagger-green.svg?logo=swagger)](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Swagger)

[![Env](https://img.shields.io/badge/Packeage-DotNetEnv-yellow.svg?logo=.ENV)](https://www.nuget.org/packages/DotNetEnv)

[![JWTBerar](https://img.shields.io/badge/Packeage-JwtBearer-yellow.svg?logo=jsonwebtokens"/)](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/9.0.0-rc.1.24452.1)    

[![Entity](https://img.shields.io/badge/Packeage-EntityFramework-purple.svg)](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/9.0.0-rc.1.24451.1)

[![EF Tools](https://img.shields.io/badge/Packeage-EntityFramework_Tools-purple.svg)](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

[![Pomelo](https://img.shields.io/badge/Packeage-Pomelo.EF.Mysql-purple.svg)](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql/9.0.0-preview.1)

[![Newtonsoft](https://img.shields.io/badge/Packeage-Newtonsoft.Json-blue.svg)](https://www.nuget.org/packages/Newtonsoft.Json/)




## Environment Variables

To run this project, you will need to add the following environment variables to your .env file
```bash
 #USER DB
UDB_PORT = 
UDB_HOST = 
UDB_NAME = 
UDB_USER = 
UDB_PASSWORD = 
#MOVEMENT DATABASE
MOVEMETDB_HOST = 
MOVEMETDB_PORT = 
MOVEMETDB_DATABASE = 
MOVEMETDB_USERNAME = 
MOVEMETDB_PASSWORD = 
#Clave secreta
key = 
```

## Run Locally(if you got SDK)

Clone the project

```bash
  git clone https://github.com/SanDaws/Zenny-Api.git
```

Go to the project directory

```bash
  cd Zenny-Api
```

Create .env file and fill the spaces whit your 2 DATABASEs data

run the project

```bash
  dotnet run
```
## Endpoints

- [See all the endpoints](ENDPOINTS.md)
