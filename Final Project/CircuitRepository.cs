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
            _conn.Execute("UPDATE aggregate_credit SET event_id = @event, tournament = @tournamentid WHERE CreditID = @id",
                new { id = aggregate_Credit.Tournament_ID, result = aggregate_Credit.Result_ID, winnings = aggregate_Credit.Winnings });
        }

        public void InsertCredit(Aggregate_Credit creditToInsert)
        {
            _conn.Execute("INSERT INTO aggregate_credit (EVENT_ID, TOURNAMENT_ID, RESULT_ID, WINNINGS) VALUES (@eventid, @tournamentid, @resultid, winnings);",
                new { eventid = creditToInsert.Event_ID, tournament = creditToInsert.Tournament_ID, result = creditToInsert.Result_ID, winnings = creditToInsert.Winnings });
        }

        public void InsertExpenses(Expenses expensesToInsert)
        {
            _conn.Execute("INSERT INTO expenses (FLIGHT, TRANSPORTATION, FOOD, HOTEL, TOTALEXPENSES) VALUES (@flight, @transportation, @food, @hotel, @totalexpenses);",
                new { flight = expensesToInsert.Flight, transportation = expensesToInsert.Transportation, food = expensesToInsert.Food, hotel = expensesToInsert.Hotel, totalexpenses = expensesToInsert.TotalExpenses });
        }

        public IEnumerable<Expenses> GetExpenses()
        {
            return _conn.Query<Expenses>("SELECT * FROM expenses;");
        }

        public Aggregate_Credit AssignExpenses()
        {
            var expensesList = GetExpenses();
            var cred = new Aggregate_Credit();
            cred.Expenses = expensesList;

            return cred ;
        }

       

        

        
    }
}
