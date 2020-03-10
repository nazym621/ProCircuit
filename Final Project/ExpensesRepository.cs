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
            _conn.Execute("INSERT INTO expenses (Flight, Transportation, Food, Hotel, TotalExpenses) VALUES (@flight, @transportation, @food, @hotel, @totalexpenses);",
                new { flight = expensesToInsert.Flight, transportation = expensesToInsert.Transportation, food = expensesToInsert.Food, hotel = expensesToInsert.Hotel, totalexpenses = expensesToInsert.TotalExpenses });

        }

        public IEnumerable<Aggregate_Credit> GetAllCredit()
        {
            return _conn.Query<Aggregate_Credit>("SELECT * FROM aggregate_credit;");
        }

        public Expenses AssignAggregateCredit()
        {
            var creditList = GetAllCredit();
            var cost = new Expenses();
            cost.AggregateCredit = creditList;

            return cost;
        }

        public IEnumerable<Tournament> GetTournament()
        {
            return _conn.Query<Tournament>("SELECT * FROM TOURNAMENTS;");
        }

    }
}
