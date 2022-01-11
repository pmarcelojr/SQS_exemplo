using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQS.Consumidor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Consumidor !");

            var client = new AmazonSQSClient(RegionEndpoint.USEast1);
            var request = new ReceiveMessageRequest
            {
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/341336031834/teste"
            };

            while (true)
            {
                var response = await client.ReceiveMessageAsync(request);

                foreach (var mensagem in response.Messages)
                {
                    // Processa a mensagem
                    Console.WriteLine(mensagem.Body);
                    // Deleta a mensagem para não voltar para a fila o tempo todo
                    await client.DeleteMessageAsync("https://sqs.us-east-1.amazonaws.com/341336031834/teste", mensagem.ReceiptHandle);
                }
            }
        }
    }
}
