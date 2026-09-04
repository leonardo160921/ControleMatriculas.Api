 ControleMatriculas.Api

API desenvolvida como parte de um teste técnico para a posição de **Desenvolvedor .NET Pleno - Back-End**.

O projeto tem como objetivo disponibilizar uma API para gerenciamento de **Alunos, Turmas e Matrículas**, utilizando uma arquitetura em camadas e integração com SQL Server através de **Dapper e Stored Procedures**.

 Tecnologias utilizadas

* C#
* .NET Framework 4.8
* ASP.NET Web API
* SQL Server
* Dapper
* Stored Procedures
* Unity
* Repository Pattern
* Arquitetura em camadas
* Git / GitHub

 Estrutura do projeto

O projeto foi organizado seguindo uma separação de responsabilidades:

```text
ControleMatriculas
│
├── Banco
│   └── Procedures
│       ├── Stored Procedures de Alunos
│       ├── Stored Procedures de Turmas
│       └── Stored Procedures de Matrículas
│
└── ControleMatriculas.Api
    ├── Controllers
    ├── Models
    ├── Repositories
    └── Configurações
```

A camada de acesso a dados utiliza **Repository Pattern**, mantendo a comunicação com o SQL Server centralizada nos repositórios.

As operações de banco de dados são realizadas através de **Stored Procedures**, mantendo os comandos SQL separados da aplicação.

 Funcionalidades

Alunos

* Listagem de alunos
* Consulta por ID
* Cadastro
* Atualização
* Exclusão lógica

### Turmas

* Listagem de turmas
* Consulta por ID
* Cadastro
* Atualização
* Exclusão lógica
* Validação de turmas com matrículas vinculadas

Matrículas

* Listagem de matrículas
* Consulta por ID
* Cadastro
* Atualização
* Exclusão
* Relacionamento entre Aluno e Turma

 Banco de Dados

O projeto utiliza **SQL Server** e as operações são realizadas através de Stored Procedures.

As procedures estão organizadas na pasta:

```text
Banco/Procedures
```

Entre elas estão:

```text
usp_Aluno_Listar
usp_Aluno_Inserir
usp_Aluno_ObterPorId
usp_Aluno_Atualizar
usp_Aluno_Excluir

usp_Turma_Listar
usp_Turma_Inserir
usp_Turma_ObterPorId
usp_Turma_Atualizar
usp_Turma_Excluir

usp_Matricula_Listar
usp_Matricula_Inserir
usp_Matricula_ObterPorId
usp_Matricula_Atualizar
usp_Matricula_Excluir
```

Desafio da configuração inicial

Uma das etapas mais trabalhosas deste projeto foi a **configuração inicial do ambiente e da aplicação**.

Antes de iniciar efetivamente o desenvolvimento dos endpoints, foi necessário configurar e validar toda a estrutura necessária para execução da API, incluindo:

* Configuração do projeto ASP.NET Web API;
* Configuração do SQL Server;
* Configuração da Connection String;
* Configuração do Dapper;
* Configuração das Stored Procedures;
* Configuração do Unity para Injeção de Dependência;
* Organização da estrutura de pastas;
* Configuração do IIS Express;
* Validação da execução da API localmente;
* Testes dos endpoints;
* Configuração do Git e integração com o GitHub.

Essa etapa foi importante porque permitiu validar que o ambiente estava funcionando corretamente antes de avançar para a implementação das funcionalidades.

Durante a configuração inicial também foram encontrados e solucionados problemas relacionados ao ambiente, execução da aplicação, dependências e integração com o banco de dados.

Testes

Os endpoints foram testados durante o desenvolvimento, validando operações de:

* GET
* GET por ID
* POST
* PUT
* DELETE

Também foram realizadas validações diretamente no SQL Server para confirmar o comportamento das Stored Procedures e a persistência dos dados.

 Controle de versão

O projeto utiliza **Git e GitHub** para controle de versão.

O desenvolvimento foi realizado de forma incremental, permitindo registrar as principais etapas da construção da API, desde a configuração inicial até a implementação dos recursos de Alunos, Turmas e Matrículas.

 Objetivo do projeto

Além de atender aos requisitos do teste técnico, o projeto foi desenvolvido buscando demonstrar conhecimentos práticos em:

* Desenvolvimento de APIs REST;
* C# e .NET;
* SQL Server;
* Dapper;
* Stored Procedures;
* Repository Pattern;
* Injeção de Dependência;
* Separação de responsabilidades;
* Validação de regras de negócio;
* Controle de versão com Git/GitHub;
* Organização de um projeto Back-End.
