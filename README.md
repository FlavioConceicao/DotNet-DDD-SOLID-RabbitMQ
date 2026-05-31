# Projeto exemplo .NET: DDD + SOLID + RabbitMQ + API

Este projeto é didático e mostra uma arquitetura simples para entrevistas de Pleno/Sênior .NET.

## Conceitos usados

- API REST
- DDD
- Entity
- Value Object
- Domain Event
- Repository
- Dependency Injection
- SOLID
- RabbitMQ
- Clean Architecture simplificada

## Estrutura

```text
Banking.Api              -> Controllers / Endpoints
Banking.Application      -> Casos de uso
Banking.Domain           -> Regras de negócio
Banking.Infrastructure   -> Banco, mensageria, integrações externas
```

## Fluxo

```text
POST /api/pix
↓
PixController
↓
PixService
↓
ContaCorrente.Transferir()
↓
PixRealizadoEvent
↓
RabbitMQPublisher
```

## Como rodar RabbitMQ com Docker

```bash
docker run -d --hostname rabbit-local --name rabbitmq \
  -p 5672:5672 -p 15672:15672 \
  rabbitmq:3-management
```

Acesse:

```text
http://localhost:15672
```

Usuário: guest  
Senha: guest
