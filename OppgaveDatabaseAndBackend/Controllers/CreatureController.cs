using Microsoft.AspNetCore.Mvc;

namespace OppgaveDatabaseAndBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreatureController : ControllerBase
    {
        private SqlReader reader;
        public CreatureController(IConfiguration configuration) 
        { 
            var connectionString = configuration.GetConnectionString("SqlConnection"); 
            // here SqlConnection is the name of the connection string in the appsettings.json file 
            // the configuration manages to retrieve the field from the file when the name here matches one's 
            reader = new SqlReader(connectionString);
        }
        [Route("/Creature/")]
        [HttpGet]
        public Task<List<Creature>> GetBosses()
        {
            return reader.GetWowCreatures();
        }
        [Route("/Creatures/{CreatureType}")]
        [HttpGet]
        public async Task < List <Creature>> GetCreatures(string CreatureType)
        {
            return await reader.GetWowCreature(CreatureType);
        }
    }
}
