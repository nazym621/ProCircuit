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
            _conn.Execute("UPDATE Aggregate_Credit SET N = @name, Price = @price WHERE ProductID = @id",
                new { id = aggregate_Credit.Tournament_ID, result = aggregate_Credit.Result_ID, winnings = aggregate_Credit.Winnings });
        }

        public void InsertCredit(Aggregate_Credit creditToInsert)
        {
            _conn.Execute("INSERT INTO aggregatecredit (EVENT_ID, TOURNAMENT_ID, RESULT_ID, WINNINGS) VALUES (@eventid, @tournamentid, @resultid, winnings);",
                new { eventid = creditToInsert.Event_ID, tournament = creditToInsert.Tournament_ID, result = creditToInsert.Result_ID, winnings = creditToInsert.Winnings });
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public Aggregate_Credit AssignCategory()
        {
            var categoryList = GetCategories();
            var credit = new Aggregate_Credit();
            credit.Categories = categoryList;

            return credit;
        }






    }
}
