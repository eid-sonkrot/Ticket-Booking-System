using RestSharp;
using Newtonsoft.Json.Linq;

namespace TicketBookingSystem.Business
{
    public class CurrencyExchange
    {
        private RestRequest request = new RestRequest();

        public CurrencyExchange()
        {
            request.Timeout = -1;
            request.AddHeader("apikey", "iRD4EEGFCWYo8EZyE0qbVSWrLrDODUXk");
        }
        public double ConvertCurrency(string baseCurrency,string newCurrency,double amount)
        {
            try
            {
                var client = new RestClient($"https://api.apilayer.com/fixer/convert?to={newCurrency}&from={baseCurrency}&amount={amount}");
                RestResponse response = client.Execute(request);
                var content = response.Content;
                JObject jsonObject = JObject.Parse(content);

                return jsonObject["result"].Value<double>();
            }catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
