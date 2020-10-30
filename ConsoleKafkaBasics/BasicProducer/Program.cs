using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace BasicProducer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string bootstrapServers = "127.0.0.1:9092";
            string nomeTopic = "meu-topico-legal";

            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = bootstrapServers,
                    EnableIdempotence = true,
                    Acks = Acks.All,
                    MessageSendMaxRetries = int.MaxValue,
                    MaxInFlight = 5
                };

                using (var kafkaProducer = new ProducerBuilder<string, string>(config).Build())
                {
                    var result = await kafkaProducer.ProduceAsync(nomeTopic, new Message<string, string>() 
                    {Key = "Key2", Value = "Message2"});

                    Console.WriteLine($"Offset: {result.Offset}" );
                    Console.WriteLine($"Topic: {result.Topic}" );
                    Console.WriteLine($"Partition: {result.Partition.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
