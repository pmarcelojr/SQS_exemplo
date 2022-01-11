using System;
using Amazon;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQS.Fornecedor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Fornecedor !");

            var client = new AmazonSQSClient(RegionEndpoint.USEast1);
            var request = new SendMessageRequest
            {
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/341336031834/teste",
                MessageBody = "teste 123"
            };

            try
            {
                await client.SendMessageAsync(request);
                Console.WriteLine("Mensagem Enviada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
