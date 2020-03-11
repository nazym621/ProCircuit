using Dapper;
using ProCircuit.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProCircuit
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly IDbConnection _conn;

        public TournamentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Tournament> GetAllTournaments()
        {
            return _conn.Query<Tournament>("SELECT * FROM TOURNAMENT;");
        }

        public Tournament GetTournament(int id)
        {
            return (Tournament)_conn.QuerySingle<Tournament>("SELECT * FROM Tournament WHERE ID = @id",
                new { id = id });
        }

        public void UpdateTournament(Tournament tournament)
        {
            _conn.Execute("UPDATE tournament SET Name = @name, Total_Prize = @totalprize WHERE ID = @id",
                new { name = tournament.Name, money = tournament.Total_Prize, id = tournament.ID });
        }

        public void InsertTournament(Tournament tournamentToInsert)
        {
            _conn.Execute("INSERT INTO tournament (Name, Total_Prize) VALUES (@name, @totalprize);",
                new { name = tournamentToInsert.Name, totalprize = tournamentToInsert.Total_Prize });
        }

       

        public IEnumerable<CircuitTournaments> GetTournaments()
        {
            return _conn.Query<CircuitTournaments>("SELECT * FROM circuittournaments;");
        }

        public Tournament AssignCircuitTournaments()
        {
            var circuitList = GetTournaments();
            var cost = new Tournament();
            cost.CircuitTournaments = circuitList;

            return cost;
        }






    }
}
