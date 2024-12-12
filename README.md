# CabeleleilaLeila

Esta solução é uma proposta de solução ao desafio proposto pela DSIN Tecnologia da Informação, visando uma vaga no Setor de Desenvolvimento.

Este projeto foi desenvolvido em .NET 8, e utiliza tecnologia JWT para proteção da API, contando com um projeto MVC exclusivo de front-end. A persistência fica por conta de banco de dados SQL Server, através do ORM Entity Framework Core.

Para rodar o projeto:
- Atualize a connection string do banco de dados em CabeleleilaLeilaInfra > Configuration.cs > GetConnectionString();
- Execute a migration com o comando Update-Database usando o projeto CabeleleilaLeilaInfra como referência;
- O id do cliente está fixo no código para testes, então copie um Id gerado no momento da migration para a variável CabeleleilaLeilaClienteApi > Controllers > AgendamentoController > _clienteId;
- Execute ambos os projetos (CabeleleilaLeilaClienteApi e CabeleleilaLeilaCliente) ao mesmo tempo.
- Execute preferencialmente no Visual Studio ou Rider.

* O projeto é apresentado no estado em que se encontra no momento do envio, estando por finalizar.

Abaixo alguns prints:

## API

![image](https://github.com/user-attachments/assets/7ed9f880-37ef-49fe-9fcf-717c23e65061)

A API possui endpoins para consulta de agendamentos (listagem e busca de item único), criação e atualização, bem como cancelamento (obedencendo a regra dos dois dias mencionado no documento). Também possui um endpoin não protegido por jwt para consulta dos serviços disponíveis.

## Projeto MVC

Pensado como mobile-first, seguem as telas do sistema. Atualmente os fluxos ainda não estão finalizados (a consulta à API é feita apenas para buscar os serviços).

### Tela inicial
![image](https://github.com/user-attachments/assets/b0280fc5-19ed-45c8-9592-dcdf66fe682c)

### Step 1 - Agendamento
![image](https://github.com/user-attachments/assets/7edc19cf-0fba-43f8-bc04-4ae5dfae1e9d)

### Step 2 - Agendamento
![image](https://github.com/user-attachments/assets/31898f62-0fc3-4ce9-a17b-978f759cf4cc)

### Step 3.1 - Agendamento
![image](https://github.com/user-attachments/assets/481e1b0a-e369-49c5-b749-c9de2f8d8bd0)

### Step 3.2 (Cliente novo) - Agendamento
![image](https://github.com/user-attachments/assets/e7bfa2dd-ea7f-408b-93e0-5bf25e465841)

### Step 4 (ainda não implementado) - Agendamento
Nesse passo, o sistema irá apresentar um resumo e solicitar a confirmação, fazendo a comunicação com o back-end para registro via API.

### Step 1 - Login
![image](https://github.com/user-attachments/assets/f7460c07-58b4-4a71-b25b-04cc09dbbef6)

### Step 2 - Login
![image](https://github.com/user-attachments/assets/f79ec8b9-97b6-4da1-8832-ae62ea26135a)

A ideia no login é adicionar o usuário na sessão, a partir de um código de uso único.
