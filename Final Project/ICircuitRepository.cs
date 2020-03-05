using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project
{
    public interface ICircuitRepository
    {
        public IEnumerable<Aggregate_Credit> GetAllCredit();
        public Aggregate_Credit GetCredit(int id);
        public void UpdateCredit(Aggregate_Credit Aggregate_Credit);
    }
}
