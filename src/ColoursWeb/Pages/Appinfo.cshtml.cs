using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ColourWeb.Pages
{
    public class ConfiginfoModel : PageModel
    {
        IConfiguration _config;
        public string strConfigHtml;

        public ConfiginfoModel(IConfiguration config)
        {
            _config = config;
            strConfigHtml = "";
        }
        public void OnGet()
        {
            strConfigHtml += "<ul>";
            strConfigHtml += "<li>Sistema Operativo: " + System.Runtime.InteropServices.RuntimeInformation.OSDescription + "</li>";
            strConfigHtml += "<li>Framework: " + System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription + "</li>";
            strConfigHtml += "<li>ASPNETCORE_ENVIRONMENT: " + _config.GetValue<string>("ASPNETCORE_ENVIRONMENT") + "</li>";
            strConfigHtml += "<li>InstrumentationKey: " + _config.GetValue<string>("ApplicationInsights:InstrumentationKey") + "</li>";
            strConfigHtml += "<li>BuildIdentifier: " + _config.GetValue<string>("BuildIdentifier") + "</li>";
            strConfigHtml += "</ul>";
        }
    }
}