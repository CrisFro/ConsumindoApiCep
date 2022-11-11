
using Refit;

namespace ConsumindoApiCep
{
    class MainClass
    {
        static async Task Main(string[] args) //asynk task - trabalha de forma assíncrona.
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br"); //passando a interface que queremos mapear + host url
                Console.WriteLine("Informe seu cep: ");

                string cepInformado = Console.ReadLine().ToString(); //capturando cep digitado
                Console.WriteLine("Consultando informações do CEP: " + cepInformado);

                var address = await cepClient.GetAddressAsync(cepInformado); //criando chamada ao refit - await serve para que aguarde o processamento

                Console.Write($"\nLogradouro:{address.Logradouro}\nBairro:{address.Bairro}\nCidade:{address.Localidade}\nIbge:{address.Ibge}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na consulta de cep: " + e.Message);
            }
        }
    }


}
