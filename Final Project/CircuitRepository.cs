using Dapper;
using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project
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




    }
}
