using System;
using System.Data;
using System.Data.SqlClient;

namespace TFSDemo
{
   public class SqlQueries
   {
      public object UnsafeQuery(
         string connection, string name, string password)
      {
         SqlConnection someConnection = new SqlConnection(connection);
         SqlCommand someCommand = new SqlCommand();
         someCommand.Connection = someConnection;

         someCommand.CommandText = "SELECT AccountNumber FROM Users " +
            "WHERE Username='" + name + 
            "' AND Password='" + password + "'";

         someConnection.Open();
         object accountNumber = someCommand.ExecuteScalar();
         someConnection.Close();
         return accountNumber;
      }

      public object SaferQuery(
         string connection, string name, string password)
      {
         SqlConnection someConnection = new SqlConnection(connection);
         SqlCommand someCommand = new SqlCommand();
         someCommand.Connection = someConnection;

         someCommand.Parameters.Add(
            "@username", SqlDbType.NChar).Value = name;
         someCommand.Parameters.Add(
            "@password", SqlDbType.NChar).Value = password;
         someCommand.CommandText = "SELECT AccountNumber FROM Users " + 
            "WHERE Username=@username AND Password=@password";

         someConnection.Open();
         object accountNumber = someCommand.ExecuteScalar();
         someConnection.Close();
         return accountNumber;
      }
   }
}