﻿using api.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Implementation
{
    public partial class DbImplementation : IDbService
    {
        private SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.AppSettings["myConnectionString"]);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }
    }
}
