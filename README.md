# 💳 API Bancária com DDD, SOLID e RabbitMQ

Projeto desenvolvido em .NET 8 utilizando conceitos modernos de arquitetura de software amplamente utilizados em empresas de médio e grande porte.

## 🚀 Tecnologias

- .NET 8
- ASP.NET Core
- DDD (Domain-Driven Design)
- SOLID
- Clean Architecture
- RabbitMQ
- Dependency Injection
- Swagger
- REST API
- Docker
- Git
- GitHub

---

## 📂 Estrutura do Projeto

src/

├── Banking.Api

├── Banking.Application

├── Banking.Domain

└── Banking.Infrastructure

### Camadas

#### Domain

Contém:

- Entidades
- Value Objects
- Eventos de Domínio
- Interfaces

#### Application

Contém:

- Commands
- Services
- Casos de Uso
- Regras de Aplicação

#### Infrastructure

Contém:

- Repositórios
- RabbitMQ
- Integrações Externas

#### API

Contém:

- Controllers
- Swagger
- Endpoints REST

---

## 🏗 Conceitos Aplicados

### DDD

Separação das responsabilidades de negócio através de:

- Entities
- Value Objects
- Domain Events
- Repositories

### SOLID

Aplicação dos princípios:

- Single Responsibility Principle
- Open/Closed Principle
- Liskov Substitution Principle
- Interface Segregation Principle
- Dependency Inversion Principle

### Mensageria

Publicação de eventos utilizando RabbitMQ.

Exemplo:

```csharp
await _messagePublisher.PublishAsync(
    new PixRealizadoEvent(conta.Id, valor)
);
```

---

## 🔄 Fluxo do PIX

1. Requisição chega na API
2. Command é criado
3. Serviço executa regra de negócio
4. Evento de domínio é gerado
5. RabbitMQ publica o evento
6. Consumidores recebem a mensagem

---

## ▶️ Executando o Projeto

### Restaurar pacotes

```bash
dotnet restore
```

### Compilar

```bash
dotnet build
```

### Executar

```bash
dotnet run --project src/Banking.Api
```

---

## 🐳 RabbitMQ com Docker

```bash
docker run -d ^
--hostname rabbit ^
--name rabbitmq ^
-p 5672:5672 ^
-p 15672:15672 ^
rabbitmq:3-management
```

Painel:

http://localhost:15672

Usuário:

```text
guest
```

Senha:

```text
guest
```

---

## 📖 Swagger

Após iniciar:

```text
https://localhost:5001/swagger
```

ou

```text
http://localhost:5000/swagger
```

---

## 🎯 Objetivo

Projeto criado para estudo e demonstração prática de:

- Arquitetura Limpa
- DDD
- SOLID
- Mensageria
- APIs REST
- RabbitMQ

Tecnologias frequentemente exigidas em vagas de Desenvolvedor .NET Pleno e Sênior.

---

## 👨‍💻 Autor

Flávio Portugal

LinkedIn:
https://www.linkedin.com/in/flavio-portugal-ramos-da-conceição-59931250/

GitHub:
https://github.com/FlavioConceicao