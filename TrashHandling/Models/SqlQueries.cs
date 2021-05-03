using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace TrashHandling.Models
{
	/// <summary>
	/// The class for SQL Queries
	/// <para>Created by Martin</para>
	/// </summary>
	public class SqlQueries
	{		
		//Connectionstring to database is fetched from App.config which is ignored by GitHub
		private static SqlConnection connectionString = 
			new(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

		/// <summary>
		/// Logic to insert a Trash object into the db.
		/// <para>Created by Martin</para>
		/// </summary>
		/// <param name="trash">The trash element that will be put into the database</param>
		public static void InsertTrashToDb(Trash trash)
		{
			try
			{
				SqlCommand insert = new(
					@"INSERT INTO TrashTable (amount,units,category,trashDescription,responsiblePerson,companyId,registerTimestamp)
					VALUES(@Amount, @Units, @Category, @Description, @ResponsiblePerson, @CompanyId, @Timestamp)", connectionString);
				insert.Parameters.Add("@Amount", SqlDbType.Decimal).Value = trash.Amount;
				insert.Parameters.Add("@Units", SqlDbType.Int).Value = trash.Units;
				insert.Parameters.Add("@Category", SqlDbType.NVarChar).Value = trash.Category;
				insert.Parameters.Add("@Description", SqlDbType.NVarChar).Value = trash.Description;
				insert.Parameters.Add("@ResponsiblePerson", SqlDbType.NVarChar).Value = trash.ResponsiblePerson;
				insert.Parameters.Add("@CompanyId", SqlDbType.Int).Value = trash.CompanyId;
				insert.Parameters.Add("@Timestamp", SqlDbType.NVarChar).Value = trash.RegisterTimeStamp;

				connectionString.Open();
				insert.ExecuteNonQuery();

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				if (connectionString != null && connectionString.State == ConnectionState.Open) connectionString.Close();
			}
		}

		public static List<Trash> GetTrashFromDb()
		{
			List<Trash> trash = new();
			try
			{
				SqlCommand selectAll = new(@"SELECT * FROM TrashTable", connectionString);
				connectionString.Open();
				SqlDataReader dbReader = selectAll.ExecuteReader();

				while (dbReader.Read())
				{

					trash.Add(new Trash
					{
						Id = int.Parse(dbReader[0].ToString()),
						Amount = decimal.Parse(dbReader[1].ToString()),
						Units = int.Parse(dbReader[2].ToString()),
						Category = dbReader[3].ToString(),
						Description = dbReader[4].ToString(),
						ResponsiblePerson = dbReader[5].ToString(),
						CompanyId = int.Parse(dbReader[6].ToString()),
						RegisterTimeStamp = string.Format("{0:yyyy:MM:dd HH:mm}", dbReader[7])
					});
				}

				dbReader.Close();
				return trash;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				trash.Clear();
				return trash;
			}
			finally
			{
				if (connectionString != null && connectionString.State == ConnectionState.Open) connectionString.Close();
			}

		}
	}
}
