# TesteApp

## Configurando
Para configurar e executar os serviços alguns parâmetros devem ser informados.
### Teste.WebApi
Será necessário especificar o caminho do banco de dados MySQL a ser utilizado na aplicação.

Edite o arquivo appsettings.json e altere a "ConnectionString" "conexao" com as informações pertinenstes ao seu servidor MySQL.

### Teste.AppWeb
Já para o front-end será necessário informar o caminho do projeto Teste.WebApi.

Edite o arquivo appsettings.json e ealtere a entrada "AppTestApi" informando o endereço do serviço (obs: não adicionar a barra ao final).

## Executando
Execute inicialmente o aplication Teste.WebApi.

Em seguinda, execute o aplicativo Teste.WebApp.
