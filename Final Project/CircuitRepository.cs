using Dapper;
using ProCircuit.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProCircuit
{
    public class CircuitRepository : ICircuitRepository
    {
        private readonly IDbConnection _conn;

        public CircuitRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Aggregate_Credit> GetAllCredit()
        {
            return _conn.Query<Aggregate_Credit>("SELECT * FROM AGGREGATE_CREDIT;");
        }

        public Aggregate_Credit GetCredit(int id)
        {
            return (Aggregate_Credit)_conn.QuerySingle<Aggregate_Credit>("SELECT * FROM AGGREGATE_ID WHERE CREDITID = @id",
                new { id = id });
        }

        public void UpdateCredit(Aggregate_Credit aggregate_Credit)
        {
            _conn.Execute("UPDATE aggregate_credit SET event_id = @event, tournament = @tournamentid WHERE CreditID = @id",
                new { id = aggregate_Credit.Tournament_ID, result = aggregate_Credit.Result_ID, winnings = aggregate_Credit.Winnings });
        }

        public void InsertCredit(Aggregate_Credit creditToInsert)
        {
            _conn.Execute("INSERT INTO aggregate_credit (EVENT_ID, TOURNAMENT_ID, RESULT_ID, WINNINGS) VALUES (@eventid, @tournamentid, @resultid, winnings);",
                new { eventid = creditToInsert.Event_ID, tournament = creditToInsert.Tournament_ID, result = creditToInsert.Result_ID, winnings = creditToInsert.Winnings });
        }

        

       

        

        
    }
}
