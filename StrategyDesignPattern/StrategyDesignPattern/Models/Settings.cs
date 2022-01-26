using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyDesignPattern.Models
{
    public class Settings
    {
        public static string claimDatabaseType = "databasetype";

        public EDatabaseType DatabaseType;

        public EDatabaseType GetDefaultDatabaseType => EDatabaseType.SqlServer;
    }
}