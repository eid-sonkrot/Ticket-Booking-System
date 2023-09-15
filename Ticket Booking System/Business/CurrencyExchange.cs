using RestSharp;
using Newtonsoft.Json.Linq;

namespace TicketBookingSystem.Business
{
    //TODO It is better to define the vale -1 as a constant
    //configuration file
    //Suppose that your request was failed, the JSON file you are trying to parse does not exist. So check if the response was successful before parsing it
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
                //exception or return an error message
                return 0;
            }
        }
    }
}
