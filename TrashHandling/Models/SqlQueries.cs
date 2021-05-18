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
		public static void InsertTrashToDb(Trash trash, DateTime dateTimePickerValue)
		{
			try
			{
				SqlCommand insert = new(
					@"INSERT INTO TrashTable (amount,units,category,trashDescription,responsiblePerson,companyId,registerTimestamp)
					VALUES(@Amount, @Units, @Category, @Description, @ResponsiblePerson, @CompanyId, @Timestamp)", connectionString);
				insert.Parameters.Add("@Amount", SqlDbType.Decimal).Value = trash.Amount;
				insert.Parameters.Add("@Units", SqlDbType.Int).Value = trash.Unit;
				insert.Parameters.Add("@Category", SqlDbType.Int).Value = trash.Category;
				insert.Parameters.Add("@Description", SqlDbType.NVarChar).Value = trash.Description;
				insert.Parameters.Add("@ResponsiblePerson", SqlDbType.NVarChar).Value = trash.ResponsiblePerson;
				insert.Parameters.Add("@CompanyId", SqlDbType.Int).Value = trash.CompanyId;
				insert.Parameters.Add("@Timestamp", SqlDbType.DateTime).Value = dateTimePickerValue;

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

		/// <summary>
		/// Logic to pull the data from our db.
		/// <para>Created by Martin</para>
		/// </summary>
		/// <param name="trash">The trash element that will be shown as a row in our datagrid</param>
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
						Unit = int.Parse(dbReader[2].ToString()),
						Category = int.Parse(dbReader[3].ToString()),
						Description = dbReader[4].ToString(),
						ResponsiblePerson = dbReader[5].ToString(),
						CompanyId = int.Parse(dbReader[6].ToString()),

						//Date must according to project be in format YYYY:MM:DD HH:mm
						RegisterTimeStamp = $"{(DateTime)dbReader[7]:yyyy:MM:dd HH:mm}"
					});
				}

				dbReader.Close();
				return trash;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return trash;
			}
			finally
			{
				if (connectionString != null && connectionString.State == ConnectionState.Open) connectionString.Close();
			}

		}

		/// <summary>
		/// Logic to change a post in the db with the Id of the passed Trash object.
		/// <para>Created by Martin</para>
		/// </summary>
		/// <param name="trash">The trash element that was edited</param>
		public static void EditTrashInDb(Trash trash)
		{
			try
			{
				if (connectionString != null && connectionString.State == ConnectionState.Open) connectionString.Close();
				SqlCommand updateElement = new(@"UPDATE TrashTable SET amount=@Amount,units=@Units,category=@Category,trashDescription=@Description,
				responsiblePerson=@ResponsiblePerson,companyId=@CompanyId,registerTimestamp=@Timestamp WHERE Id=@Id", connectionString);
				updateElement.Parameters.Add("@Id", SqlDbType.Int).Value = trash.Id;
				updateElement.Parameters.Add("@Amount", SqlDbType.Decimal).Value = trash.Amount;
				updateElement.Parameters.Add("@Units", SqlDbType.Int).Value = trash.Unit;
				updateElement.Parameters.Add("@Category", SqlDbType.Int).Value = trash.Category;
				updateElement.Parameters.Add("@Description", SqlDbType.NVarChar).Value = trash.Description;
				updateElement.Parameters.Add("@ResponsiblePerson", SqlDbType.NVarChar).Value = trash.ResponsiblePerson;
				updateElement.Parameters.Add("@CompanyId", SqlDbType.Int).Value = trash.CompanyId;
				updateElement.Parameters.Add("@Timestamp", SqlDbType.DateTime).Value = DateTime.Parse(trash.DateTimePickerValue);

				connectionString.Open();
				updateElement.ExecuteNonQuery();
				connectionString.Close();
			}
			catch (Exception updateEx)
			{
				MessageBox.Show(updateEx.Message);
			}
			finally
			{
				if (connectionString != null && connectionString.State == ConnectionState.Open) connectionString.Close();
			}
		}

		/// <summary>
		/// Logic to delete a Trash object from the db.
		/// <para>Created by Martin</para>
		/// </summary>
		/// <param name="trash">The trash element that will be deleted</param>
		public static void DeleteTrashFromDb(Trash trash)
		{
			try
			{
				SqlCommand deleteElement = new(@"DELETE FROM TrashTable WHERE Id=@Id", connectionString);
				deleteElement.Parameters.Add("@Id", SqlDbType.Int).Value = trash.Id;

				connectionString.Open();
				deleteElement.ExecuteNonQuery();
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
