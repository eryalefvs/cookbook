# CookBook
Este projeto consiste em uma API desenvolvida em .NET para o gerenciamento de receitas culinárias. A API permite que os usuários se cadastrem fornecendo nome, e-mail e senha. Após o cadastro, os usuários podem criar, editar, filtrar e deletar receitas. Cada receita deve incluir um título, ingredientes e instruções. Adicionalmente, os usuários têm a opção de adicionar o tempo de preparo, nível de dificuldade e uma imagem ilustrativa à receita.

Seguindo os princípios de Domain-Driven Design (DDD) e SOLID, a arquitetura do projeto busca manter um design modular e sustentável. A validação dos dados é realizada utilizando FluentValidation, assegurando que todas as entradas de dados atendam aos critérios estabelecidos.

Para garantir a qualidade do código, são implementados testes de unidade e de integração. A utilização de injeção de dependências promove uma melhor modularidade e testabilidade do código, facilitando a manutenção e evolução do projeto.

Outras tecnologias e práticas adotadas incluem o Entity Framework para o mapeamento objeto-relacional, a metodologia ágil SCRUM para o gerenciamento do projeto, e a implementação de Tokens JWT & Refresh Token para autenticação segura. As migrações do banco de dados são gerenciadas para assegurar uma evolução controlada do esquema de dados. Além disso, o uso de Git e a estratégia de ramificação GitFlow auxiliam na organização e controle das versões do código.

## Principais features
- Cadastro de Usuários: Como permitir o registro de usuários com validação de email e senha.
- Gerenciamento de Receitas: Criação, edição, exclusão e filtro de receitas.
- Login com Google: Integração para autenticação via conta Google.
- Integração com ChatGPT: Utilização de IA para melhorar a experiência do usuário.
- Mensageria: Utilização de mensageria para gerenciar a exclusão de contas.
- Segurança: Implementação de JWT e Refresh Token para segurança de autenticação.
- Banco de Dados: Configuração e uso de MySQL ou SQLServer.
- DevOps: Configuração de pipelines CI/CD e integração com Sonarcloud para análise contínua.
- Arquitetura: Princípios de Domain-Driven Design (DDD) e SOLID.
- Validação: Utilização de FluentValidation para validação de dados.
- Testes: Implementação de testes de unidade e de integração para garantir a qualidade do código.
- Injeção de Dependências: Uso de injeção de dependências para melhor modularidade e testabilidade do código.
