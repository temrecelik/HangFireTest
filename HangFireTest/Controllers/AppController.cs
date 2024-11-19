using Hangfire;
using HangFireTest.Background;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFireTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            //burada kuyruğu alınıyor end point tetiklenince enqueue'den processing'e geçiyor
            BackgroundJob.Enqueue("aaaa",() => BackGService.Test());
            return Ok("Hangfire Çalıştı");
        }
    }

}
