using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace App2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            await HttpContext.Session.LoadAsync();
            HttpContext.Session.TryGetValue("test", out byte[] value);
            var str = "0";
            if (value != null) str = System.Text.Encoding.Default.GetString(value);
            IncrementCache("test");
            return Ok(str);
        }

        private void IncrementCache(string key)
        {
            HttpContext.Session.TryGetValue(key, out byte[] value);
            var str = "0";
            var num = 0;
            if (value != null)
            {
                str = System.Text.Encoding.Default.GetString(value);
                int.TryParse(str, out num);
            }
            num = num + 1;
            var bytes = System.Text.Encoding.Default.GetBytes(num.ToString());
            HttpContext.Session.Set("test", bytes);
            HttpContext.Session.CommitAsync();
        }
    }
}
