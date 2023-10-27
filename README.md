# Projeto de Exemplo: Uso do Padrão Mediator e Separação por Use Cases

Este é um projeto de exemplo que demonstra o uso do padrão Mediator e a separação por use 
cases na camada de aplicação. Ele serve como uma referência para estudos sobre arquitetura 
de software e boas práticas de organização de código.

## Visão Geral

Neste projeto, é explorado como aplicar o padrão Mediator para desacoplar componentes do sistema 
e facilitar a comunicação entre eles. Além disso, seguimos uma arquitetura baseada na separação 
por use cases para organizar a lógica da aplicação de forma clara e modular.

## Tecnologias Utilizadas

- Linguagem de Programação: C#
- Outras bibliotecas/frameworks: 
- - [MediaR](https://www.nuget.org/packages/MediatR/)
- - [FluentValidation](https://docs.fluentvalidation.net/en/latest/)

## Estrutura do Projeto

A estrutura do projeto segue a organização típica considerando projetos para API, Applicatin, Domain, Repository e IoC
```
projeto-exemplo/
├── src/
│ ├── Prototipo.Exemplo.Api/
│ │ ├── Controllers/
│ │ ├── Filters/
│ ├── Prototipo.Exemplo.Application/
│ │ ├── _Shared/
│ │ ├── DTOs/
│ │ ├── Events/
│ │ ├── UseCases/
│ ├── Prototipo.Exemplo.Domain/
│ │ ├── _Shared/
│ │ ├── Cursos/
│ │ ├── Instituicoes/
│ │ ├── Ofertas/
│ ├── Prototipo.Exemplo.Infra.Postgress/
│ │ ├── _Shared/
│ │ ├── Context/
│ │ ├── Repositories/
│ ├── Prototipo.Exemplo.IoC/
│ │ ├── Extensions/
```


## Observações do Controller de Cursos

Este documento fornece uma visão geral da classe `CursosController` e descreve os endpoints RESTful disponíveis para 
gerenciar cursos do microserviço.

### CursosController

A classe CursosController desempenha um papel de gerenciamento das solicitações HTTP relacionadas a cursos na aplicação. Ela 
adota o padrão Mediator para estabelecer uma separação clara entre as responsabilidades do controlador e a lógica de negócios 
subjacente. Os métodos desta controller têm uma abordagem minimalista, concentrando-se exclusivamente no processamento de 
comandos e consultas, sem tratamentos de erros ou ações adicionais que não estejam diretamente relacionadas a essas operações.

Os parâmetros dos métodos podem utilizar o contrato das commands para compreender claramente as informações necessárias que o 
endpoint precisa fornecer para que o comando seja executado com sucesso. Essa abordagem garante que as entradas e saídas da API 
estejam alinhadas de maneira eficaz com as operações da camada de aplicação.

#### Métodos

- **GET /cursos**

  - Descrição: Retorna uma lista de cursos com base nos parâmetros fornecidos na query string.
  - Parâmetros da Query String:
    - `query`: Um objeto contendo parâmetros para pesquisa.
  - Exemplo de Uso: `/cursos?nome=nomedocurso`
  - Resposta: Retorna uma lista de DTOs de cursos que correspondem aos parâmetros de pesquisa fornecidos

- **POST /cursos**

  - Descrição: Cria um novo curso com base nos dados fornecidos no corpo da solicitação.
  - Corpo da Solicitação: Um objeto contendo informações do curso a ser criado.
  - Exemplo de Uso: `/cursos`
  - Resposta: Retorna Id do curso recém-criado.

- **GET /cursos/{cursoId}**

  - Descrição: Retorna informações detalhadas sobre um curso específico com base no ID fornecido.
  - Parâmetros de Rota:
    - `cursoId`: O ID único do curso.
  - Exemplo de Uso: `/cursos/{guid}`
  - Resposta: Retorna informações detalhadas sobre o curso especificado.

- **PUT /cursos/{cursoId}**

  - Descrição: Atualiza um curso existente com base no ID fornecido e nos dados fornecidos no corpo da solicitação.
  - Parâmetros de Rota:
    - `cursoId`: O ID único do curso a ser atualizado.
  - Corpo da Solicitação: Um objeto contendo informações atualizadas do curso.
  - Exemplo de Uso: `/cursos/{guid}`
  - Resposta: Retorna um status de sucesso após a atualização do curso.

- **DELETE /cursos/{cursoId}**

  - Descrição: Remove um curso existente com base no ID fornecido.
  - Parâmetros de Rota:
    - `cursoId`: O ID único do curso a ser removido.
  - Corpo da Solicitação: Não é necessário no corpo da solicitação.
  - Exemplo de Uso: `/cursos/{guid}`
  - Resposta: Retorna um status de sucesso após a remoção do curso.

#### Injeção de Dependência

O controller `CursosController` faz uso da injeção de dependência para obter uma instância de `IMediator`, permitindo assim que ele envie comandos e consultas para a camada de aplicação.

```csharp
public CursosController(IMediator mediator)
{
    _mediator = mediator;
}
```