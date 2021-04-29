using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace TrashHandling.Models
{	
	public class SqlQueries
	{		
		//Connectionstring to database is fetched from App.config which is ignored by GitHub
		private static SqlConnection connectionString = 
			new(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
		
		/// <summary>
		/// Logic to insert a Trash object into the db.
		/// <para>Created by Martin Nørholm</para>
		/// </summary>
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
	}
}
