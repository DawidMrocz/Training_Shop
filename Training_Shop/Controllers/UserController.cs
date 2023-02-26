using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using Training_Shop.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _config;
        public UserController
            (
                ILogger<UserController> logger,
                IConfiguration config
            ) 
        {
            _logger = logger;
            _config = config;
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
