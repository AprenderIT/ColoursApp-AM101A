using ColoursWeb;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ColourWeb.Pages
{
    public class IndexModel : PageModel
    {

        public string Api { get; set; }
        public bool Direct { get; set; }
        List<ColoursItem2> ColorsList { get; set; } = new List<ColoursItem2>();
        public string Colors { get; set; } = "";

        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void OnGet()
        {
            var api = Request.Cookies.FirstOrDefault(x => x.Key == "APIUrl");

            if (api.Value is not null)
            {
                Api = api.Value;
            }
            else
            {
                Api = "https://coloursapi.app.aprender.it/colours/random";
            }

            Response.Cookies.Append("APIUrl", Api);

            var mode = Request.Cookies.FirstOrDefault(x => x.Key == "APIMode");

            if (mode.Value is not null)
            {
                Direct = mode.Value == "Direct";
            }

            Response.Cookies.Append("APIMode", Direct ? nameof(Direct): "");

        }
        // the click event handler 
        // MUST be prefixed with OnGet if the 
        // request is of HTTP GET type 
        public async Task OnGetOnClick()
        {
            var api = Request.Cookies.FirstOrDefault(x => x.Key == "APIUrl");
            Api = api.Value;

            var mode = Request.Cookies.FirstOrDefault(x => x.Key == "APIMode");

            if (mode.Value is not null)
            {
                Direct = mode.Value == "Direct";
            }

            for (int i = 0; i < 400; i++)
            {

                try
                {
                    var color = await _httpClient.GetFromJsonAsync<ColoursItem2>(api.Value);
                    ColorsList.Add(color);
                }
                catch (Exception)
                {
                    await Task.Delay(200);
                    var color = await _httpClient.GetFromJsonAsync<ColoursItem2>(api.Value);
                    ColorsList.Add(color);
                }
                

                

            }

            Colors = string.Join(",", ColorsList.Select(x => x.Data));


        }

    }
}
