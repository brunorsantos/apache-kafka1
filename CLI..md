## Kafka topics

Comando kaka-topics mostra a documentação da opcao.

Exemplos usando docker-compose

```

docker-compose exec kafka  kafka-topics --zookeeper zookeeper:2181 --create --topic first_topic --partitions 1 --replication-factor 1

```
Deve sempre informar o server do zookeeper ao se trabalhar com topicos.
Para se criar deve se informar sempre o numero de partições daquele tópico juntamento o replication-factor, que nao pode ser maior que numero de brokers.


```
docker-compose exec kafka  kafka-topics --zookeeper zookeeper:2181 --list
```

Lista todos os topicos

```
docker-compose exec kafka  kafka-topics --zookeeper zookeeper:2181 --topic first_topic --describe
```

Descreve detalhes do topico

```
docker-compose exec kafka  kafka-topics --zookeeper zookeeper:2181 --topic second_topic --delete
```

Deleta um topico

## Console producer

Envia mensagens via console

```
docker-compose exec kafka  kafka-console-producer --broker-list 127.0.0.1:9092 --topic first_topic
```

Deve ser sempre informado o broker list em que producer enviará as mensagens

Caso o envio seja feito para o um topico nao existente, será criado um topico novo com os valores padroes  configurados no kafka (1 partition e 1 replication factor) ao enviar a primeira mensagem

O comando abrira um console para enviar uma mensagem por vez

## Console consumer

```
docker-compose exec kafka  kafka-console-consumer --bootstrap-server 127.0.0.1:9092 --topic first_topic
``` 

Abre um console de um consumer que receberá as mensagens. Apenas a partir daquele momento.


```
docker-compose exec kafka  kafka-console-consumer --bootstrap-server 127.0.0.1:9092 --topic first_topic
``` 

```
docker-compose exec kafka  kafka-console-consumer --bootstrap-server 127.0.0.1:9092 --topic first_topic --from-beginning
```

Para receber as mensagens desde o inicio (com consumer group essa opcao só funcionará na primeira vez)

```
docker-compose exec kafka  kafka-console-consumer --bootstrap-server 127.0.0.1:9092 --topic meu-topico-legal --group my-first-application
```

## Console consumer group


```
docker-compose exec kafka  kafka-consumer-groups --bootstrap-server 127.0.0.1:9092 --describe --group my-first-application
``` 

Exibirá como o consumer-group está em relacao a todas a partitions do topic (principalmente em relação a offset)