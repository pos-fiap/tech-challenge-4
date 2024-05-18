### Estória 1: Criar Livro

**Como** um usuário do sistema  
**Quero** ser capaz de adicionar um novo livro à biblioteca  
**Para** registrar novas obras e torná-las disponíveis para os usuários  

**Critérios de Aceitação:**  
- Ao fornecer um título, autor e ID de gênero válido e enviar uma solicitação POST para a rota `/api/book`, um novo livro deve ser criado na biblioteca.
- Se algum campo obrigatório não for enviado na solicitação ou estiver vazio, o sistema deve retornar um status HTTP 400 (Bad Request) com uma mensagem de erro indicando o campo ausente.
- Se o ID do gênero fornecido não existir no sistema, o sistema deve retornar uma mensagem de erro informando que o gênero não foi encontrado. 

<br><br>

### Estória 2: Listar Livros

**Como** um usuário do sistema  
**Quero** ser capaz de visualizar uma lista de todos os livros disponíveis  
**Para** escolher os livros que desejo ler ou obter informações sobre eles  

**Critérios de Aceitação:**  
- Cada livro na lista deve exibir o título, autor e nome do gênero.
- A lista deve ser ordenada alfabeticamente pelo título do livro.

<br><br>

### Estória 3: Atualizar Livro

**Como** um usuário do sistema  
**Quero** ser capaz de atualizar as informações de um livro existente  
**Para** corrigir erros nos detalhes do livro ou atualizá-los conforme necessário  

**Critérios de Aceitação:**  
- Ao enviar uma solicitação PUT para a rota `/api/book/{id}` com os campos de título, autor e ID de gênero preenchidos corretamente, as informações do livro correspondente devem ser atualizadas na biblioteca.
- Se o livro não existir, o sistema deve retornar uma mensagem de erro informando que o livro não foi encontrado.
- Se o ID do gênero fornecido não existir no sistema, o sistema deve retornar uma mensagem de erro informando que o gênero não foi encontrado. 

<br><br>

### Estória 4: Excluir Livro

**Como** um usuário do sistema  
**Quero** ser capaz de excluir um livro existente da biblioteca  
**Para** remover livros que não são mais relevantes ou estão incorretos  

**Critérios de Aceitação:**  
- Ao enviar uma solicitação DELETE para a rota `/api/book/{id}`, o livro correspondente deve ser removido da biblioteca.
- Se o livro não existir, o sistema deve retornar uma mensagem de erro informando que o livro não foi encontrado.
- Após a exclusão bem-sucedida, o sistema deve retornar um status HTTP 204 (No Content) indicando que a operação foi realizada com sucesso.

<br><br>

### Estória 5: Obter Livros por Gênero

**Como** um usuário do sistema  
**Quero** ser capaz de obter uma lista de livros de um gênero específico  
**Para** encontrar livros que se encaixem em minhas preferências de leitura  

**Critérios de Aceitação:**  
- Ao enviar uma solicitação GET para a rota `/api/book/getbygenre/{genreId}`, o sistema deve retornar uma lista de livros que pertencem ao gênero especificado.
- A lista deve conter apenas os livros que têm o ID de gênero correspondente ao fornecido na solicitação.
- Se não houver livros para o gênero especificado, o sistema deve retornar uma mensagem de erro informando que não foram encontrados livros para esse gênero.
