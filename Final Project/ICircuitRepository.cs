﻿using ProCircuit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace ProCircuit
{
    public interface ICircuitRepository
    {
        public IEnumerable<Aggregate_Credit> GetAllCredit();
        public Aggregate_Credit GetCredit(int id);
        public void UpdateCredit(Aggregate_Credit Aggregate_Credit);
        public void InsertCredit(Aggregate_Credit creditToInsert);
        public void InsertTournament(Tournament tournamentToInsert);
        public IEnumerable<Tournament> GetTournament();
        public Tournament AssignTournament();
        public void InsertExpenses(Expenses expensesToInsert);
        public IEnumerable<Expenses> GetExpenses();
        public Expenses AssignExpenses();


    }
}
