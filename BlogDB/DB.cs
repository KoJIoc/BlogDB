using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace BlogDB
{
	public class DB
	{
		MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3307;username=root;password=root;database=blogdb;charset=utf8");

		public void OpenConnection()
		{
			if (connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
		}
		public void CloseConnection()
		{
			if (connection.State == ConnectionState.Open)
			{
				connection.Close();
			}
		}

		public MySqlConnection GetConnection()
		{
			return connection;
		}
	}
}
