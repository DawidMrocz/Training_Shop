using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using Training_Shop.Application.Services.Authentication;
using Training_Shop.Contracts.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IConfiguration _config;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController
            (
                ILogger<AuthenticationController> logger,
                IConfiguration config,
                IAuthenticationService authenticationService
            ) 
        {
            _logger = logger;
            _config = config;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("/register")]
        public ActionResult<AuthenticationResult> Register([FromBody]RegisterRequest request)
        {
            var authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                    authResult.Id,
                    authResult.FirstName,
                    authResult.LastName,
                    authResult.Email,
                    authResult.Password
                );

            return Ok(response);
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login([FromBody]LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                    authResult.Id,
                    authResult.FirstName,
                    authResult.LastName,
                    authResult.Email,
                    authResult.Password
                );

            return Ok(response);
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            using SqlConnection connection = new(_config.GetConnectionString("DefaultConnection"));
            string sql = "SELECT USERID,NAME FROM USERS";
            IEnumerable<User> users = await connection.QueryAsync<User>(sql);
            return Ok(users);
        }

        [HttpGet]
        [Route("/SearchUser")]
        public async Task<ActionResult<User>> GetSearchUser([FromQuery]string phrase)
        {
            using SqlConnection connection = new(_config.GetConnectionString("DefaultConnection"));
            string sql = "SELECT USERID,NAME FROM USERS WHERE NAME LIKE @SearchBy";
            var parameters = new {SearchBy = "%" + phrase + "%"};
            IEnumerable<User> users = await connection.QueryAsync<User>(sql, parameters);
            return Ok(users);
        }

        [HttpGet]
        [Route("/User/{userId}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int userId)
        {
            using SqlConnection connection = new(_config.GetConnectionString("DefaultConnection"));
            string sql = "SELECT USERID,NAME FROM USERS WHERE ID = @ID";
            var parameters = new { ID = userId };
            User? user = await connection.QueryFirstOrDefaultAsync<User>(sql, parameters);
            if (user == null) return NotFound("User not found!");
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
