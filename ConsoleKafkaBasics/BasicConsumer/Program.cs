using Confluent.Kafka;
using System;
using System.Threading;

namespace BasicConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            string bootstrapServers = "127.0.0.1:9092";
            string nomeTopic = "meu-topico-legal";
            string groupName = "my-first-application";

            try
            {
                var config = new ConsumerConfig()
                {
                    BootstrapServers = bootstrapServers,
                    GroupId = groupName,
                    AutoOffsetReset = AutoOffsetReset.Earliest,   
                    EnableAutoCommit = false,
                    maxB
                };

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                using (var consumer = new ConsumerBuilder<string, string>(config).Build())
                {
                    consumer.Subscribe(nomeTopic);

                    try
                    {
                        while (true)
                        {

                            var cr = consumer.Consume(cts.Token);

                            
                            Console.WriteLine(
                                $"Mensagem lida: {cr.Message.Value}");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                        Console.WriteLine("Cancelada a execução do Consumer...");
                    }

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
