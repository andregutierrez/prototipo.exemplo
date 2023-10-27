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
- - [MediaR] (https://www.nuget.org/packages/MediatR/)
- - [FluentValidation] (https://docs.fluentvalidation.net/en/latest/)

## Estrutura do Projeto

A estrutura do projeto segue a organização típica de uma aplicação separada por use cases:
`
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
`