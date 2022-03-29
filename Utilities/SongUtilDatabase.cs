using System;
using System.IO;
using System.Collections.Generic;
using PA3.Models;
using PA3.FileHandleing;
using PA3.Interfaces;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace PA3.Utilities 
{
	public class SongUtilDatabase : ISongUtilities
	{
		public List<Song> playlist {get; set;}
		void ISongUtilities.PrintPlaylist()
		{
			List<Song> playlist = new List<Song>();

			ConnectionString myConnection = new ConnectionString();
			string cs = myConnection.cs;

			using var con = new MySqlConnection(cs);
			con.Open();
		
			string stm = "SELECT * FROM skz2znkwczaxt80m.songs ORDER BY date desc;";
			using var cmd = new MySqlCommand(stm, con);

			using MySqlDataReader rdr = cmd.ExecuteReader();

			while(rdr.Read())
			{
				Song temp = new Song(){SongID=rdr.GetInt32(0), SongTitle=rdr.GetString(1), SongTimestamp=rdr.GetDateTime(2)};
				// Song temp = new Song(){SongID = int.Parse(temp[0]), SongTitle = temp[1], SongTimestamp = DateTime.Parse(temp[2]), Deleted = temp[3]});
				playlist.Add(temp);
			}
		}
		
		void ISongUtilities.AddSong()
		{
			ConnectionString myConnection = new ConnectionString();
			string cs = myConnection.cs;
			using var con = new MySqlConnection(cs);
			con.Open();

			string stm = @"INSERT INTO songs(title, date) VALUES(@title, @date)";

			using var cmd = new MySqlCommand(stm, con);

			Console.WriteLine("What is the title of the song you would like to add?");
			
			string Text = Console.ReadLine();
			DateTime Date = DateTime.Now;

			cmd.Parameters.AddWithValue("@title", Text);
			cmd.Parameters.AddWithValue("@date", Date);

			cmd.Prepare();

			cmd.ExecuteNonQuery();
		}
		
		void ISongUtilities.DeleteSong()
		{
			Console.WriteLine("What is the id of the song you would like to delete?");
			int id = int.Parse(Console.ReadLine());
			string stm = $@"DELETE FROM `skz2znkwczaxt80m`.`songs` WHERE (`id` = {id})";

			ConnectionString myConnection = new ConnectionString();
			string cs = myConnection.cs;

			using var con = new MySqlConnection(cs);
			con.Open();

			using var cmd = new MySqlCommand(stm, con);

			cmd.ExecuteNonQuery();
		}
		
		void ISongUtilities.EditSong()
		{
			ConnectionString myConnection = new ConnectionString();
			string cs = myConnection.cs;
			using var con = new MySqlConnection(cs);
			con.Open();

			Console.WriteLine("What is the id of the song you want to edit?");
			int id = int.Parse(Console.ReadLine());

			string stm = $@"UPDATE songs SET title = @title WHERE (`id` = {id})";
			using var cmd = new MySqlCommand(stm, con);

			Console.WriteLine("What would you like to edit the song to be?");
			
			string Text = Console.ReadLine();
			DateTime Date = DateTime.Now;

			cmd.Parameters.AddWithValue("@title", Text);
			cmd.Parameters.AddWithValue("@date", Date);

			cmd.Prepare();

			cmd.ExecuteNonQuery();
		}
	}
}