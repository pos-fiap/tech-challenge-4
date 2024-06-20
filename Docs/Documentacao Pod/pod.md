# Guia de Configuração do Kubernetes com Docker Desktop

<br>

## 1º Passo - Habilitar o Kubernetes no Docker Desktop
![enable kubernetes](enable%20kubernetes.png)

<br>

## 2º Passo - Subir uma Imagem da API no Hub 

*Este passo é opcional caso utilize a imagem que já está no hub (`lgmbx/tech5:v1`)*

Na raiz onde está o Dockerfile, executar os comandos:

```sh
docker login  # para logar no Docker

docker build -t {seu_login_do_hub}/{nome_da_image}:{tag}  # para buildar a imagem

docker push {seu_login_do_hub}/{nome_da_image}:{tag}  # para enviar a imagem para o hub
```





<br>


## 3º Passo - Alterar o arquivo pod.yml

*Este passo é opcional caso utilize a imagem que já está configurada no arquivo pod.yml*

O arquivo pod.yml está na pasta yaml, na raiz do projeto.

![pod.yml](pod%20yml.png)


<br>

## 4º Passo - Executar o Pod

Em um terminal, navegue até a pasta yaml e execute os comandos:

```sh
kubectl apply -f pod.yml  # para criar um pod da imagem

kubectl port-forward tech5 {porta}:8080  # cria um túnel entre as portas e expõe para ser acessada
```


<br>


## 5º Passo - Acessar o swagger

No navegador, acesse localhost com a porta configurada no comando port-forward

Ex: localhost:{porta}/swagger