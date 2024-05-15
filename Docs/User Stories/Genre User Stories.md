### Est�ria 1: Criar G�nero

**Como** um desenvolvedor consumindo a API  
**Quero** ser capaz de criar um novo g�nero  
**Para** adicionar novas categorias de conte�do no sistema  

**Crit�rios de Aceita��o:**  
- Quando enviar uma solicita��o POST para a rota `/api/genres` com os campos obrigat�rios preenchidos corretamente, um novo g�nero deve ser criado no sistema.
- Se algum campo obrigat�rio n�o for enviado na solicita��o ou estiver vazio, a API deve retornar uma mensagem de erro indicando o campo ausente.

<br><br>


### Est�ria 2: Listar G�neros

**Como** um desenvolvedor consumindo a API  
**Quero** ser capaz de obter uma lista de todos os g�neros dispon�veis  
**Para** integrar essa informa��o em diferentes partes do sistema  

**Crit�rios de Aceita��o:**  
- Quando enviar uma solicita��o GET para a rota `/api/genres`, a API deve retornar uma lista contendo todos os g�neros cadastrados no sistema.
- Cada item da lista deve conter o nome e a descri��o do g�nero.
- A lista deve ser ordenada alfabeticamente pelo nome do g�nero.


<br><br>


### Est�ria 3: Atualizar G�nero

**Como** um desenvolvedor consumindo a API  
**Quero** ser capaz de atualizar as informa��es de um g�nero existente  
**Para** corrigir erros ou atualizar detalhes conforme necess�rio  

**Crit�rios de Aceita��o:**  
- Quando enviar uma solicita��o PUT para a rota `/api/genres/{id}` com os campos de nome e descri��o preenchidos corretamente, as informa��es do g�nero correspondente devem ser atualizadas no sistema.
- Se o g�nero n�o existir, a API deve retornar  uma mensagem de erro informando que o g�nero n�o existe.


<br><br>


### Est�ria 4: Excluir G�nero

**Como** um desenvolvedor consumindo a API  
**Quero** ser capaz de excluir um g�nero existente  
**Para** remover categorias de conte�do obsoletas do sistema  

**Crit�rios de Aceita��o:**  
- Quando enviar uma solicita��o DELETE para a rota `/api/genres/{id}`, o g�nero correspondente deve ser removido do sistema.


