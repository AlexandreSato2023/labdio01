using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LabDioAI01
{
    public class SalesForecastService
    {
        public async Task<string> GetSalesForecast(string sellDate)
        {
            var handler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
            };

            using (var client = new HttpClient(handler))
            {

                var mlModel = new MachineLearningModel();
                mlModel.input_data = new Input_Data();
                mlModel.input_data.index = new List<int> { 1 };
                mlModel.input_data.columns = new List<string>();
                mlModel.input_data.columns.Add("Data");
                mlModel.input_data.columns.Add("Condicoes_Climaticas");
                mlModel.input_data.data = new List<Datum>()
                {
                    new Datum()
                    {

                          Data = sellDate
                    }
                };
                string output = JsonConvert.SerializeObject(mlModel);

                // Replace this with the primary/secondary key or AMLToken for the endpoint
                const string apiKey = "EbZnXXWByBNgqN0FMUklXXXXXXXXXX";
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new Exception("A key should be provided to invoke the endpoint");
                }
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://icecreamsalesiamodel.centralus.inference.ml.azure.com/score");

                var content = new StringContent(output);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // This header will force the request to go to a specific deployment.
                // Remove this line to have the request observe the endpoint traffic rules
                content.Headers.Add("azureml-model-deployment", "icecreamsalesiamodel-1");

                // WARNING: The 'await' statement below can result in a deadlock
                // if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false)
                // so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)
                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Result: {0}", result);

                    return result;
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);

                    throw new Exception("The request failed with status code: {0}\", response.StatusCode");
                }
            }
        }

    }

}
