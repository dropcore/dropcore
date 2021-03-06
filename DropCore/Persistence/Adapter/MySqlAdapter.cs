﻿using MySql.Data.MySqlClient;
using System.Data;

namespace DropCore.Persistence.Adapter
{
    public class MySqlAdapter : IPersistenceAdapter
    {
        public IDbConnection Create(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }
}
