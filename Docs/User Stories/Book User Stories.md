### Est�ria 1: Criar Livro

**Como** um usu�rio do sistema  
**Quero** ser capaz de adicionar um novo livro � biblioteca  
**Para** registrar novas obras e torn�-las dispon�veis para os usu�rios  

**Crit�rios de Aceita��o:**  
- Ao fornecer um t�tulo, autor e ID de g�nero v�lido e enviar uma solicita��o POST para a rota `/api/books`, um novo livro deve ser criado na biblioteca.
- Se algum campo obrigat�rio n�o for enviado na solicita��o ou estiver vazio, o sistema deve retornar um status HTTP 400 (Bad Request) com uma mensagem de erro indicando o campo ausente.
- Se o ID do g�nero fornecido n�o existir no sistema, o sistema deve retornar uma mensagem de erro informando que o g�nero n�o foi encontrado. 

<br><br>

### Est�ria 2: Listar Livros

**Como** um usu�rio do sistema  
**Quero** ser capaz de visualizar uma lista de todos os livros dispon�veis  
**Para** escolher os livros que desejo ler ou obter informa��es sobre eles  

**Crit�rios de Aceita��o:**  
- Cada livro na lista deve exibir o t�tulo, autor e nome do g�nero.
- A lista deve ser ordenada alfabeticamente pelo t�tulo do livro.

<br><br>

### Est�ria 3: Atualizar Livro

**Como** um usu�rio do sistema  
**Quero** ser capaz de atualizar as informa��es de um livro existente  
**Para** corrigir erros nos detalhes do livro ou atualiz�-los conforme necess�rio  

**Crit�rios de Aceita��o:**  
- Ao enviar uma solicita��o PUT para a rota `/api/books/{id}` com os campos de t�tulo, autor e ID de g�nero preenchidos corretamente, as informa��es do livro correspondente devem ser atualizadas na biblioteca.
- Se o livro n�o existir, o sistema deve retornar uma mensagem de erro informando que o livro n�o foi encontrado.
- Se o ID do g�nero fornecido n�o existir no sistema, o sistema deve retornar uma mensagem de erro informando que o g�nero n�o foi encontrado. 

<br><br>

### Est�ria 4: Excluir Livro

**Como** um usu�rio do sistema  
**Quero** ser capaz de excluir um livro existente da biblioteca  
**Para** remover livros que n�o s�o mais relevantes ou est�o incorretos  

**Crit�rios de Aceita��o:**  
- Ao enviar uma solicita��o DELETE para a rota `/api/books/{id}`, o livro correspondente deve ser removido da biblioteca.
- Se o livro n�o existir, o sistema deve retornar uma mensagem de erro informando que o livro n�o foi encontrado.
- Ap�s a exclus�o bem-sucedida, o sistema deve retornar um status HTTP 204 (No Content) indicando que a opera��o foi realizada com sucesso.

<br><br>

### Est�ria 5: Obter Livros por G�nero

**Como** um usu�rio do sistema  
**Quero** ser capaz de obter uma lista de livros de um g�nero espec�fico  
**Para** encontrar livros que se encaixem em minhas prefer�ncias de leitura  

**Crit�rios de Aceita��o:**  
- Ao enviar uma solicita��o GET para a rota `/api/books/getbygenre/{genreId}`, o sistema deve retornar uma lista de livros que pertencem ao g�nero especificado.
- A lista deve conter apenas os livros que t�m o ID de g�nero correspondente ao fornecido na solicita��o.
- Se n�o houver livros para o g�nero especificado, o sistema deve retornar uma mensagem de erro informando que n�o foram encontrados livros para esse g�nero.
