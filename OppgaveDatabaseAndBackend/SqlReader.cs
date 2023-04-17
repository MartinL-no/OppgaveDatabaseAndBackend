using System.Data.SqlClient;
using Dapper;

namespace OppgaveDatabaseAndBackend
{
    public class SqlReader
    {
        private string _connectionString;

        public SqlReader(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<List<Boss>> GetWowBosses()
        {
            List<Boss> bosses= new List<Boss>();
            var query = $"Select * From Boss";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                bosses = connection.Query <Boss>(query).ToList();
            }
            return bosses;
        }
        public async Task<List<string>> GetWowBossNames()
        {
            List<string> bossNames= new List<string>();
            var query = $"Select Name From Boss";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                bossNames = connection.Query <string>(query).ToList();
            }
            return bossNames;
        }
        public async Task<List<Creature>> GetWowCreatures()
        {
            List<Creature> creatures= new List<Creature>();
            var query = $"Select * From Creature";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                creatures = connection.Query <Creature>(query).ToList();
            }
            return creatures;
        }
        public async Task<List<Creature>> GetWowCreature(string creatureType)
        {
            List<Creature> creatures = new List<Creature>();
            var query = $"Select * From Creature Where CreatureType = '{creatureType}'";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                creatures = connection.Query <Creature>(query).ToList();
            }
            return creatures;
        }
    }
}