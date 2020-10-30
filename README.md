# apache-kafka1
Anotações de estudo de apache kafka

## Core concepts

### Producer
Aplicacao que envia dado (mensagem) para kafka em formato de bytes

### Consumer

Aplicacao que recebe dado do kafka não recebe diretamente do producer. O consumer quem solicita para o kafka as mensagens

### Broker

É o kakfa server. 

### Cluster
Grupos de maquinas rodando os broker

### Topic
Identificador de uma categoria de mensagens que o consumer esta vinculado a ela

### Partitions

Pequenas partes do topic dividas pelo cluster. O arquiteto decide o numero de partições ao criar o topico na criaçao do mesmo, sendo que uma partica nao pode ser quebra
 
### Partitions Offset

Identificador unico de cada mensagem dentro de uma partição de um topico

### Consumer Group
Serve para incluir multiplas copias de um mesmo consumer afim de auxiliar na escalabilidade. Sendo que o numero de consumers dentro de um consumer group está diretamente relacionado ao numero de partitions, pois o kafka nao permite que mais de um consumer de uma mesmo consumer group leia da mesma partition ao mesmo tempo

### Kafka Connect

Componente do kafka que que conecta e move data entre aplicaçoes externas, sem necessidade de desenvolvimento.
Existem dois tipo de kafka connectors. Source connector que pega dados de uma origem utilizando API de producers e Sink connector que envia dados para um destino uilizando API de consumers
O kafka connector framework permite a criacao de connectors para o kafka desenvolvidos em java, que que os mesmos sao disponibilizados em jar. 
Os connectors podem ser utilizados em connect cluster com workers para escalabilidade.
É possivel como kafka connector fazer single message transformations como: Adicionar novos campos, filtrar ou renomear campos, mascarar campos, mudar chave do registro e rotear resgistos para diferentes topicos. Porem essas transformações nao sao sufientes para alguns casos reais
O kafka connect funciona com um cluster que contera com varios workers em um worker group que serão as instancias que terão varias tasks que irão trabalhar com leitura dos dados (no caso de source connector). A configuração de separação de task a rodar em paralelo juntamente com outras cofiguração é feita quando se instala o connector do kafka connect escolhido no cluster

### Kafka Streams

Streams são dados sem limites, infinitos e sequenciais.