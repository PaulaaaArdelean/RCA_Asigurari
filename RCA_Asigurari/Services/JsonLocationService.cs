using RCA_Asigurari.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace RCA_Asigurari.Services
{

    public class JsonLocationService
    {
        public async Task<List<JsonLocation>> ReadJsonFileAsync(string jsonFilePath)
        {
            using (StreamReader file = File.OpenText(jsonFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<JsonLocation>)await Task.Run(() => serializer.Deserialize(file, typeof(List<JsonLocation>)));
            }
        }
    }
}
