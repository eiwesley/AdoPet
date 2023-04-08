# AdoPet Api

# Challenge Back-End 6ª edição

## API Rest
![Badge em desenvolvimento](https://img.shields.io/badge/Status-Em%20Desenvolvimento-green)

## :hammer_and_wrench: Objetivo do projeto

O objetivo do Alura Challenge é aplicar os conhecimentos obtidos através dos cursos disponíveis na plataforma. Recebemos os cards de desafio ao início de cada uma das 4 semans de challenge. Não há restrição quanto a qual técnologia deva ser utilizada pelos alunos, ficando a cargo de cada um decidir como irá construir o projeto.

### História

Após alguns testes com protótipos feitos pelo time de UX de uma empresa, foi requisitada a primeira versão de uma plataforma para adoção de Pets. A plataforma deve permitir ao usuário se comunicar com a ONG de adoção, para informar a intensão de adoção.<br>
Os times de frontend e UI já estão trabalhando no layout e nas telas. Para o backend, as principais funcionalidades a serem implementadas são:

<ul>

   <li> API com rotas implementadas segundo o padrão REST;</li>
   <li> Validações feitas conforme as regras de negócio;</li>
   <li> Implementação de base de dados para persistência das informações;</li>
   <li> Serviço de autenticação para acesso às rotas POST, GET, PUT e PATCH.</li>
   
</ul>

## :white_check_mark: Semana 1

- [x] Armazenar no banco de dados as informações sobre os tutores
- [x] Todos os campos de tutor devem ser obrigatórios e validados.
- [x] Implementar para /tutores POST/GET/GET_ID/PUT/PATCH.
- [x] PUT atualiza um ou mais campos de um tutor. Retornar um Json com informações do tutor atualizado.

## :construction: Semana 2

- [x] Armazenar no banco de dados as informações sobre os pets.
- [x] Implementar para /pets POST/GET/GET_ID/PUT/PATCH.
- [x] Validar se a url imagem do pet cadastrado é verdadeira.
- [x] Implemente uma relação entre tutor e Pet, atribuindo para cada Pet um Tutor.
- [x] Criar uma rota `GET` relacionando `tutores` e `pet`, exemplo: `GET pets/tutor/:id`. 
- [x] Armazenar no banco de dados as informações sobre os abrigos.
- [x] Implementar para /abrigos POST/GET/GET_ID/PUT/PATCH.
- [x] Criar uma rota 'POST' para nova adoção, caso todos os pets estejam preenchidos e validados.
- [x] criar uma rota 'DELETE' para adoção, caso o nível do perfil seja Admin ou Abrigo.

## :soon: Semana 3 e 4

- Ainda não divulgado
<!-- - [ ] Sistema de autenticação. -->
<!-- - [ ] Alteração no banco de dados para tabela de usuário.-->
<!-- - [ ] Deploy.-->

## ✔️ Tecnologias utilizadas

- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [EntityFrameworkCore 7.0](https://learn.microsoft.com/en-us/ef/)
- [AutoMapper 12.0](https://automapper.org/)
- [NewtonsoftJson 6.0](https://www.newtonsoft.com/json)
- [SQL Sever 2022](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Swagger](https://swagger.io/)
<!--- [IdentityFramework 7.0](https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-7.0&tabs=visual-studio) -->
<!--- [JWT Bearer](https://jwt.io/introduction) -->
<!--- [FluentResults](https://github.com/altmann/FluentResults) -->
<!--- [DotEnv](https://github.com/bolorundurowb/dotenv.net) -->

<br>

## :hammer_and_wrench: Abrir e rodar o projeto

Clone o projeto para seu repositório.
<br>
Instale as dependências através do comando:

`dotnet restore`

Configure sua connection string pelo user-secrets com o comando:

`dotnet user-secrets "DbConnection" "SUA_STRING_AQUI"`

Criar a base de dados:

`Update-Database`

O adminstrador deve ser criado direto no banco de dados e deve ser atribuído o papel amdmin para o mesmo.

<!-- Crie um arquivo `.env` na raiz do projeto PlayListAPI seguindo o modelo do arquivo `.env.example` -->
<br><br>

