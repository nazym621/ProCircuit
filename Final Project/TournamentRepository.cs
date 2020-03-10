using Dapper;
using ProCircuit.Models;
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
                new { name = tournament.Name, money = tournament.Total_Prize, id = tournament.TournamentID });
        }

        public void InsertTournament(Tournament tournamentToInsert)
        {
            _conn.Execute("INSERT INTO Tournament (ID, Name, Total_Prize) VALUES (@id, @name, @totalprize);",
                new { id = tournamentToInsert.TournamentID, name = tournamentToInsert.Name, totalprize = tournamentToInsert.Total_Prize, });
        }

        public IEnumerable<Aggregate_Credit> GetAllCredit()
        {
            return _conn.Query<Aggregate_Credit>("SELECT * FROM aggregate_credit;");
        }

        public Tournament AssignAggregateCredit()
        {
            var creditList = GetAllCredit();
            var tourney = new Tournament();
            tourney.AggregateCredit = creditList;

            return tourney;
        }





    }
}
