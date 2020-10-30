using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionConsumer
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([KafkaTrigger("BootstrapServer", "meu-topico-legal", ConsumerGroup = "ConsumerGroup")]KafkaEventData<string> mySbMsg, ILogger log)
        {

            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg.Value}");
            throw new System.Exception("teste1");
        }
    }
}
