using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;


namespace CurrencyService
{
    public class CurrencyService : ICurrencyService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public async Task<string> GetCurrency(string currency)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"https://api.nbp.pl/api/exchangerates/rates/A/{currency}/?format=json");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            return string.Empty;

        }
        public async Task<string> GetTable()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.nbp.pl/api/exchangerates/tables/C/?format=json");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            return string.Empty;
        }

        public async Task<string> GetGold()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.nbp.pl/api/cenyzlota/?format=json");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            return string.Empty;

        }
    


public CompositeType GetDataUsingDataContract(CompositeType composite)
{
    if (composite == null)
    {
        throw new ArgumentNullException("composite");
    }
    if (composite.BoolValue)
    {
        composite.StringValue += "Suffix";
    }
    return composite;
}
    }
}
