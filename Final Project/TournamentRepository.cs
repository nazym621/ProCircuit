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
                new { name = tournament.Name, money = tournament.TotalPrize, id = tournament.TournamentID });
        }

        public void InsertCredit(Aggregate_Credit creditToInsert)
        {
            _conn.Execute("INSERT INTO Aggregate_Credit (ID, Event_ID, Result_ID, Tournament_ID, Winnings) VALUES (@id, @eventid, @resultid, tournamentid, winnings);",
                new { eventid = creditToInsert.Event_ID, result = creditToInsert.Result_ID, tournament = creditToInsert.Tournament_ID, winnings = creditToInsert.Winnings });
        }

        public IEnumerable<Aggregate_Credit> GetCredit()
        {
            return _conn.Query<Aggregate_Credit>("SELECT * FROM aggregate_credit;");
        }

        public Aggregate_Credit AssignAggregateCredit()
        {
            var creditList = GetCredit();
            var tourney = new Tournament();
            tourney.AggregateCredit = creditList;

            return tourney;
        }





    }
}
