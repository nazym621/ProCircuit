using Dapper;
using ProCircuit.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProCircuit
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly IDbConnection _conn;

        public ExpensesRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Expenses> GetAllExpenses()
        {
            return _conn.Query<Expenses>("SELECT * FROM EXPENSES;");
        }

        public Expenses GetExpenses(int totalexpenses)
        {
            return (Expenses)_conn.QuerySingle<Expenses>("SELECT * FROM EXPENSES WHERE TOTALEXPENSES = @totalexpenses",
                new { totalexpenses = totalexpenses });
        }

        public void UpdateExpenses(Expenses expenses)
        {
            _conn.Execute("UPDATE expenses SET Flight = @flight, Transportation = @transportation, Food = @food, Hotel = @hotel WHERE TotalExpenses = @totalexpenses",
                new { flight = expenses.Flight, transportation = expenses.Transportation, food = expenses.Food, hotel = expenses.Hotel, totalexpenses = expenses.TotalExpenses });
        }

        public void InsertExpenses(Expenses expensesToInsert)
        {
            _conn.Execute("INSERT INTO expenses (Flight, Transportation, Food, Hotel) VALUES (@flight, @transportation, @food, @hotel);",
                new { flight = expensesToInsert.Flight, transportation = expensesToInsert.Transportation, food = expensesToInsert.Food, hotel = expensesToInsert.Hotel });

        }

        public IEnumerable<CircuitTournaments> GetTournaments()
        {
            return _conn.Query<CircuitTournaments>("SELECT * FROM circuittournaments;");
        }

        public Expenses AssignCircuitTournaments()
        {
            var circuitList = GetTournaments();
            var cost = new Expenses();
            cost.CircuitTournaments = circuitList;

            return cost;
        }

        public void DeleteExpenses(Expenses expenses)
        {
            _conn.Execute("DELETE FROM Flight WHERE ID = @id;",
                                       new { id = expenses.ExpensesID });
            _conn.Execute("DELETE FROM Transportation WHERE ID = @id;",
                                       new { id = expenses.ExpensesID });
            _conn.Execute("DELETE FROM Food WHERE ID = @id;",
                                       new { id = expenses.ExpensesID });
            _conn.Execute("DELETE FROM Hotel WHERE ID = @id;",
                                      new { id = expenses.ExpensesID });
            _conn.Execute("DELETE FROM TotalExpenses WHERE ID = @id;",
                                      new { id = expenses.ExpensesID });
        }




    }
}
