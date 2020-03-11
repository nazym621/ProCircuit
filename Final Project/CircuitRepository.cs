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

        public IEnumerable<CircuitTournaments> GetAllTournaments()
        {
            return _conn.Query<CircuitTournaments>("SELECT * FROM CIRCUITTOURNAMENTS;");
        }

        public CircuitTournaments GetTournaments(int id)
        {
            return (CircuitTournaments)_conn.QuerySingle<CircuitTournaments>("SELECT * FROM CIRCUITTOURNAMENTS WHERE ID = @id",
                new { id = id });
        }

        public void UpdateTournaments(CircuitTournaments circuitTournaments)
        {
            _conn.Execute("UPDATE circuittournaments SET tournamentname = @tournamentname, prizemoney = @prizemoney, netwinnings = @netwinnings WHERE ID = @id",
                new { tournament = circuitTournaments.TournamentName, prizemoney = circuitTournaments.PrizeMoney, winnings = circuitTournaments.NetWinnings });
        }



       

        

       

        

        
    }
}
