using Refit;

namespace ConsumindoApiCep
{
    public interface ICepApiService //interface onde é chamada a API
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
