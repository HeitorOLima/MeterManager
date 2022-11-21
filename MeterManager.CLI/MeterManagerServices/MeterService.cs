using MeterManager.CLI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using System.Net.Http.Headers;

namespace MeterManager.CLI.MeterManagerServices
{
    internal class MeterService
    {
        private Uri BaseAdress { get; set; }
        private HttpClient HttpClient { get; set; }

        public MeterService()
        {
            BaseAdress = new Uri("https://localhost:7145/");
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = BaseAdress;
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //GetAllMeters
        public async Task<List<MeterDto>> GetAllMeters()
        {
            var response = await HttpClient.GetAsync("api/meters/recover");
            var meters = new List<MeterDto>();

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                meters = JsonConvert.DeserializeObject<ICollection<MeterDto>>(responseString).ToList();
            }

            return meters;
        }

        //GetMeterBySerialNumber
        public async Task<MeterDto> GetMeterBySerialNumber(string serialNumber)
        {
            var meter = new MeterDto();
            var response = await HttpClient.GetAsync($"api/meters/recover/{serialNumber}");

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                meter = JsonConvert.DeserializeObject<MeterDto>(responseString);
            }

            return meter;
        }

        //DeleteMeter
        public async Task DeleteMeter(string serialNumber)
        {
            var meter = new MeterDto();
            var response = await HttpClient.DeleteAsync("api/meters/delete/{serialNumber}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("The content was successfully deleted from the database");
            }
        }

        //UpdtaMeter

        public async Task<MeterDto> UpdateMeter(MeterDto meter)
        {

            var serializedJson = JsonConvert.SerializeObject(meter);
            var postContent = new StringContent(serializedJson.ToString(), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync($"api/meters/create/", postContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("The content was successfully updated in the database");
                return meter;
            }

            return null;
        }

        //CreateMeter
        public async Task<MeterDto> CreateMeter(MeterDto meter)
        {

            var serializedJson = JsonConvert.SerializeObject(meter);
            var postContent = new StringContent(serializedJson, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync($"api/meters/create", postContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("The content was successfully created in the database");
                return meter;
            }

            return null;
        }
    }
}
