using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Application.Commands.UserCommands;
using Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Encryption _enc;

        private readonly ILoginCommand _login;

        public AuthController(Encryption enc, ILoginCommand login)
        {
            _enc = enc;
            _login = login;
        }



        // POST: api/Auth
        [HttpPost]
        public IActionResult Post([FromBody] UserLoginDto credentials)
        {

            //ovde ide logovanje korisnika
           var user = _login.Execute(credentials);

            var stringObjekat = JsonConvert.SerializeObject(user);

            var encrypted = _enc.EncryptString(stringObjekat);

            return Ok(new { token = encrypted });
        }

        [HttpGet("decode")]
        public IActionResult Decode(string value)
        {
            var decodedString = _enc.DecryptString(value);
            decodedString = decodedString.Replace("\f", "");
            var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

            return null;
        }
    }
}
