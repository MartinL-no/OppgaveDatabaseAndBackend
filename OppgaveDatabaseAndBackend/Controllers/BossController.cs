using Microsoft.AspNetCore.Mvc;

namespace OppgaveDatabaseAndBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BossController : ControllerBase
    {
        private SqlReader reader;
        public BossController(IConfiguration configuration) 
        { 
            var connectionString = configuration.GetConnectionString("SqlConnection"); 
            // here SqlConnection is the name of the connection string in the appsettings.json file 
            // the configuration manages to retrieve the field from the file when the name here matches one's 
            reader = new SqlReader(connectionString);
        }
        [Route("/Boss/")]
        [HttpGet]
        public Task<List<Boss>> GetBosses()
        {
            return reader.GetWowBosses();
        }
        [Route("/Boss/Names")]
        [HttpGet]
        public async Task<List<string>> GetBossNames()
        {
            return await reader.GetWowBossNames();
        }
    }
}
