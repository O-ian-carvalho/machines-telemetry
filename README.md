# Plataforma de Monitoramento de Máquinas Pesadas

## Requisitos

* **.NET 8 SDK**, **Node.js 20+** e **Angular CLI**
  ou
* **Docker** e **Docker Compose**

---

## Configuração de Ambiente

A conexão com o banco é definida em `appsettings.json` e `appsettings.Docker.json`.

* Para rodar **localmente**, ajuste a string de conexão para as credenciais do seu banco:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=MachinesTelemetry;Username=postgres;Password=root"
}
```

* Para rodar **via Docker**, utilize a configuração:
  - Essa configuração já vem pré-definida ao clonar este repositório.

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=postgresdb;Port=5432;Database=MachinesTelemetry;Username=postgres;Password=root"
}
```

---

## Execução com Docker (recomendado)

Na raiz do repositório:

```bash
docker compose up -d --build
```

Serviços disponíveis:

* API: [http://localhost:5058](http://localhost:5058) (Swagger em `/swagger`)
* UI Angular: [http://localhost:4200](http://localhost:4200)
* PostgreSQL: serviço `postgresdb`, porta 5432

Para encerrar:

```bash
docker compose down
```

---

## Execução Local (sem Docker)

1. Na pasta da API:

   ```bash
   cd MachinesTelemetryApi
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

   A API ficará disponível em:

   * `http://localhost:5095`
   * `https://localhost:7207`

2. Na pasta da UI:

   ```bash
   cd machines-telemetry-ui
   npm install
   npm start
   ```

   Aplicação disponível em: `http://localhost:4200`

---

## Documentação da API

A API expõe documentação interativa via **Swagger**:

* Docker: [http://localhost:5058/swagger](http://localhost:5058/swagger)
* Local: `/swagger` na porta definida pelo `launchSettings.json`

---

## Endpoints Principais (`/api/machines`)

* **GET `/api/machines`**
  Lista todas as máquinas, com filtro opcional por status.
* **GET `/api/machines/{id}`**
  Retorna detalhes de uma máquina e sua última telemetria.
* **POST `/api/machines`**
  Cria uma nova máquina e registra a telemetria inicial.
* **PATCH `/api/machines/{id}`**
  Atualiza os dados de uma máquina.
* **POST `/api/machines/{id}/telemetries`**
  Registra uma nova telemetria para a máquina, mantendo o histórico.
* **GET `/api/machines/{id}/telemetries?pageNumber=1&pageSize=10`**
  Retorna o histórico de telemetrias, com suporte a paginação (parâmetros opcionais).

---

## Middleware Global de Erros

Todas as exceções são capturadas e transformadas em respostas padronizadas:

* **400** para validações e operações inválidas
* **404** para registros não encontrados
* **500** para erros internos

---

## Seed de Dados

Ao iniciar o projeto pela primeira vez, são criados automaticamente:

* Máquinas de exemplo
* Histórico de telemetrias para cada máquina

