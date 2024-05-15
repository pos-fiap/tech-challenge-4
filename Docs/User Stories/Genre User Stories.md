### Estória 1: Criar Gênero

**Como** um desenvolvedor consumindo a API  
**Quero** ser capaz de criar um novo gênero  
**Para** adicionar novas categorias de conteúdo no sistema  

**Critérios de Aceitação:**  
- Quando enviar uma solicitação POST para a rota `/api/genres` com os campos obrigatórios preenchidos corretamente, um novo gênero deve ser criado no sistema.
- Se algum campo obrigatório não for enviado na solicitação ou estiver vazio, a API deve retornar uma mensagem de erro indicando o campo ausente.

<br><br>


### Estória 2: Listar Gêneros

**Como** um desenvolvedor consumindo a API  
**Quero** ser capaz de obter uma lista de todos os gêneros disponíveis  
**Para** integrar essa informação em diferentes partes do sistema  

**Critérios de Aceitação:**  
- Quando enviar uma solicitação GET para a rota `/api/genres`, a API deve retornar uma lista contendo todos os gêneros cadastrados no sistema.
- Cada item da lista deve conter o nome e a descrição do gênero.
- A lista deve ser ordenada alfabeticamente pelo nome do gênero.


<br><br>


### Estória 3: Atualizar Gênero

**Como** um desenvolvedor consumindo a API  
**Quero** ser capaz de atualizar as informações de um gênero existente  
**Para** corrigir erros ou atualizar detalhes conforme necessário  

**Critérios de Aceitação:**  
- Quando enviar uma solicitação PUT para a rota `/api/genres/{id}` com os campos de nome e descrição preenchidos corretamente, as informações do gênero correspondente devem ser atualizadas no sistema.
- Se o gênero não existir, a API deve retornar  uma mensagem de erro informando que o gênero não existe.


<br><br>


### Estória 4: Excluir Gênero

**Como** um desenvolvedor consumindo a API  
**Quero** ser capaz de excluir um gênero existente  
**Para** remover categorias de conteúdo obsoletas do sistema  

**Critérios de Aceitação:**  
- Quando enviar uma solicitação DELETE para a rota `/api/genres/{id}`, o gênero correspondente deve ser removido do sistema.


