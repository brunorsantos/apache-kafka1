## Acks

acks=0 - Não é esperado resposta do broker, se ele ficar offline dados serão perdidos, melhor performance aceitaval quando possui uma coleta de metricas muito boa

acks=1 - Default do kafka 2.0. Broker manda o dado para partição leader que devolve o ok, mas sem chegar a conferir a replicação. Ainda é possivel perder o dado se o leader cair antes de enviar para a replica o dado

acks=all - Todas as replicas respondem para o producer falando que receberam os dados. Essa opção garante que os dados não são perdidos

Deve se tomar cuidado com a configuração 'min.insync.replicas' que define a quantidade de replicas devem existir para uma partição. Pois caso um quantidade de brokers caiam, todas as respostas voltarão com erro

## Idempotent Producer

Para garantir pipeline segura e estavel.

Propriedades do producer:
retries ja vem com o valor maximo de integer
max.in.flight.requests vem com valor =5
acks=all 

alem disso deve se colocar 'producerProsp.put("enable.idempotence",true)' que implementará por conta propria um requestId no entre producer e kafka que evitará duplicidade

## High Throughput producer

Alem de compressao habilitada, é possivel enviar mensagens em batch atraves das propriedades:

linger.ms - Define quantidade de milisegundos para aguardar mensagens para serem enviadas de uma unica vez para o broker em batch
batch.size - Define o tamanho maximo a ser atingido para envio em batch, mesmo que o tempo de linger não tenha sido atingido