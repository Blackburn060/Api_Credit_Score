# Api_Credit_Score
## Vehicle Insurance API

Este projeto é uma API para uma empresa de seguros de veículos que calcula o "CREDIT_SCORE" de uma pessoa com base nos dados fornecidos e em um arquivo CSV de referência.

## Estrutura do Projeto

- `VehicleInsuranceAPI`: API principal
  - `Controllers`: Controladores
  - `Models`: Modelos de dados
  - `Services`: Serviços
  - `VehicleInsuranceAPI.csproj`: Arquivo de projeto

- `VehicleInsuranceAPITests`: Projeto de testes unitários
  - `Controllers`: Testes dos controladores
  - `VehicleInsuranceAPITests.csproj`: Arquivo de projeto

## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) versão 6.0 ou superior
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)

## Exemplo de Requisição

### Url: `https://apicreditscore.azurewebsites.net`

### Endpoint: `/api/CreditScore`

**Método:** `POST`

**Exemplo de Corpo da Requisição (Body):**

```json
{
  "Age": "16-25",
  "Gender": "male",
  "YearsLicensed": "0-9y",
  "EducationLevel": "none",
  "IncomeLevel": "poverty",
  "VehicleYear": "before 2015",
  "VehicleType": "sedan",
  "AnnualMileage": "16000.0"
}