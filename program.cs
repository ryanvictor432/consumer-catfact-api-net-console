using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumerCatFactApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using HttpClient client = new HttpClient();
            string url = "https://catfact.ninja/fact"; // Endpoint fornecido[cite: 22]

            try
            {
                // Consome a API[cite: 22]
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                
                // Extrai os parâmetros fact e length do JSON[cite: 22]
                CatFactResponse? catFact = JsonSerializer.Deserialize<CatFactResponse>(responseBody);

                if (catFact != null)
                {
                    // Imprime os dados retornados na tela do console
                    Console.WriteLine("Fato sobre Gatos:");
                    Console.WriteLine(catFact.fact);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro na requisição: {e.Message}");
            }
        }
    }

    public class CatFactResponse
    {
        public string? fact { get; set; }
        public int length { get; set; }
    }
}
