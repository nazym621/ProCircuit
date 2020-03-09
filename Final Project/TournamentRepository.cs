using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace ProCircuit
{
    public class TournamentRepository: ITournamentRepository
    {
        private readonly IDbConnection _conn;

        public TournamentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Tournament> GetAllTournaments()
        {
            return _conn.Query<Tournament>("SELECT * FROM TOURNAMENTS;");
        }

        public Tournament GetTournament(string type)
        {
            return (Tournament)_conn.QuerySingle<Tournament>("SELECT * FROM Tournament WHERE TournamentType = @type",
                new { type = type });
        }

        public void UpdateTournament(Tournament tournament)
        {
            _conn.Execute("UPDATE tournament SET Name = @name, Total_Prize = @totalprize WHERE TournamentID = @id",
                new { name = tournament.Name, money = tournament.TotalPrize, id = tournament.TournamentID });
        }



    }
}
