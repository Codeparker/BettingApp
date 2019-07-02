using Newtonsoft.Json;
using ODDESTODDS.Application.DtoModels.Game;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ODDESTODDS.UnitTest
{
    public class IntegrationTest
    {
        private readonly HttpClient _http;
        public IntegrationTest()
        {
            _http = new TestClientProvider().Client;
        }

        public async Task Test_Posting_Empty_AddorEdit()
        {
           
        }

        [Fact]
        public async Task Test_Posting_Valid_AddorEdit_RedirectedtoIndex_Page()
        {
            //arrange
            var mode = new CreateGameDto()
            {
                Id = 0,
                OddId=0,
                AwayOdd = 3.4,
                HomeOdd = 4.9,
                DrawOdd = 5.0,
                HomeTeam = "TEst U1",
                AwayTeam = "Test U2",
                GameStartTime = DateTime.Now.ToString()
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(mode), Encoding.UTF8, "application/json");
            //Act
            var result = await _http.PostAsync("https://localhost:44374/BettingAdmin/AddorEdit", content);
            var stringResult = result.Content.ReadAsStringAsync();
            //Assert
            Assert.StartsWith("https://localhost:44374/BettingAdmin", result.Headers.Location.OriginalString);
        }
    }
}
