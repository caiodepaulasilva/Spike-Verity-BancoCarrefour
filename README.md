<p align="center">    
  <img src="https://github.com/caiodepaulasilva/Spike-Verity-BancoCarrefour/assets/36136627/1d20b966-01c2-49c8-9b1c-f3ebfe59d6c1"/>  
  <br><br>
  <img src="https://img.shields.io/badge/status-work%20in%20progress-red?style=for-the-badge"/>  
  <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white"/>  
  <img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white"/>    
</p>

## Introdução

Este trabalho foi desenvolvido como parte de um processo seletivo no qual o objetivo é construir um projeto de desenvolvimento web em que algumas habilidades possam ser exercitadas. E são elas:
- Domínio de capacidade de escrever a arquitetura de soluções
- Domínio de capacidade de escrever uma documentação razoável
- Domínio de construção de projeto apoiado em boas práticas
- Domínio da construção de testes unitários
- Domínio da capacidade analitica, de abstração e de construção de um algoritmo que reflita as boas práticas de programção e o uso razoável da linguagém C# para construção de APIs.

**Anexo**: O exerício proposto consta neste documento: [desafio-teste.md](https://github.com/caiodepaulasilva/Spike-Verity-BancoCarrefour/files/15140171/desafio-teste.md)
<br><br>


## Requerimentos


 O projeto tem uma construção parcialmente simples e, portanto, são necessárias apenas algumas poucas dependências para a sua execução. São esperados os seguintes requerimentos:

- Microsoft Visual Studio (versão 2010 ou superior)
- SDK .NET (versão 8.0 ou superior)
- Browser de navegação Web
- SQL Server Managament Studio
- Docker Desktop
- IIS Express
- API Gateway (Ocelot)

## Orientações:
- O projeto possui integração com Swagger disponível, portanto, é possível valida-lo através das rotas correspondentes;
- O desenho tecnico da solução e de suas integrações segue disponívle [nesta rota]();
- O projeto atende ao padrão de microsserviços, dessa maneira as chamadas são direcionadas para cada serviço (*report* e *releases*) através do **ocelot**, incluindo no projeto API;

## Execução
O projeto necessita que suas dependências diretas sejam consideradas antes de sua execução. Sendo neste caso necessário a configuração de um servidor **SQL Server** e de um **API Gateway**.  Uma vez configurados, a execução da API se tornar então possível. Segue passo-a-passo de como configura-los:

**Clonar o projeto:**
```
cd "diretorio de sua preferencia"
git clone https://github.com/caiodepaulasilva/Prova-Deliver-IT.git
```
**Criar Container SQL Server:**
1. Abra o arquivo docker-compose.yaml e defina uma senha para o servidor, através da variável *"SA_PASSWORD"*
2. Uma vez no Visual Studio, no terminal PowerShell do Desenvolvedor, na raiz do projeto, digite:
```
docker-compose up -d
```
3. Verifique o bom funcionamento através do Docker Desktop. Os containers devem ter sido criados com sucesso e estarão em execução.
4. Verifique se é possível estabelcer conexão com o servidor. Para isso tente realizar a conexão através do SQL Server Managament Studio da seguinte maneira:

| Campo do Formulário de Conexão | Valor                               |
| ------------------------------ | ----------------------------------- |
| Server Type                    | Database Engine                     |
| Server Name                    | localhost                           |
| Authentication                 | SQL Server Authentication           |
| Login                          | sa                                  |
| Password                       | <SA_PASSWORD> (docker-compose.yaml) |
| Trust server certificate       | checked                             |

**Criar a estrutura da base de dados:**
2. Uma vez no Visual Studio, no terminal PowerShell do Desenvolvedor, na raiz do projeto, digite:
```
dotnet clean
dotnet ef migrations add InitialCreate --project Infrastructure --startup-project API-Releases
```
Após a execução destas instrunções, deve ser possível executar o projeto normalmente.


## Licença

[MIT licensed](./LICENSE).
