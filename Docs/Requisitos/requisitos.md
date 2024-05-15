### 1.	Requisito Funcional 1: A aplicação deve permitir que os usuários adicionem novos livros.
	- O sistema deve fornecer uma interface para inserir detalhes do livro, como título, autor e gênero.
	- O título do livro não deve exceder 100 caracteres.
	- O nome do autor não deve exceder 50 caracteres.
	- O sistema deve fornecer feedback ao usuário sobre o sucesso ou falha da operação.
### 2.	Requisito Funcional 2: A aplicação deve permitir que os usuários visualizem todos os livros.
	- O sistema deve listar todos os livros salvos no banco de dados.
	- Cada entrada da lista deve mostrar detalhes do livro, como título, autor e gênero.
### 3.	Requisito Funcional 3: A aplicação deve permitir que os usuários adicionem novos gêneros.
	- O sistema deve fornecer uma interface para inserir o nome do gênero.
	- O nome do gênero não deve exceder 50 caracteres.
	- O sistema deve fornecer feedback ao usuário sobre o sucesso ou falha da operação.
### 4.	Requisito Funcional 4: A aplicação deve permitir que os usuários visualizem todos os gêneros.
	- O sistema deve listar todos os gêneros salvos no banco de dados.
	- Cada entrada da lista deve mostrar o nome do gênero.
### 5.	Requisito Não Funcional 1: A aplicação deve ser segura.
	- O sistema deve proteger os dados do usuário e do livro.
	- O sistema deve ter medidas para prevenir ataques comuns, como injeção de SQL.
	- O sistema deve usar criptografia para proteger dados sensíveis.
### 6.	Requisito Não Funcional 2: A aplicação deve ter um bom desempenho.
	- O sistema deve responder rapidamente às ações do usuário.
	- O sistema deve ser capaz de lidar com um grande número de livros e gêneros.
### 7.	Requisito Não Funcional 3: A aplicação deve ser compatível com Docker.
	- O sistema deve ser capaz de ser empacotado em um container Docker para facilitar a implantação.
	- O sistema deve incluir um Dockerfile que define como o container Docker é construído.
	- O sistema deve ser capaz de se conectar a um banco de dados que está em um container Docker separado.