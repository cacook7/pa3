using System;
using System.Collections.Generic;
using PA3.Models;
using PA3.Utilities;
using PA3.Interfaces;

namespace PA3
{
	class Program
	{
		static void Main(string[] args)
		{
			int userChoice = 0;
			bool keepGoing;
			// ReadFromFile readFromFile = new ReadFromFile();
			// List<Song> playlist = readFromFile.GetAll();
			// Menu programMenu = new Menu(){SongUtilities = new SongUtil(), Playlist = playlist};
			// Menu programMenu = new Menu(){SongUtilities = new SongUtilDatabase(), Playlist = playlist};
			// do {
			//     userChoice = programMenu.DisplayMainMenu(); 
			//     keepGoing = programMenu.RouteMainMenu(userChoice);
				
			// } while (keepGoing);
				int menuSelection = 0;

			while (menuSelection != 5)
			{
				if (menuSelection == 1)
				{
					ISongUtilities readObject = new PrintPlaylist();
					List<Song> playlist = readObject.PrintPlaylist();
					foreach(Song song in playlist)
					{
						Console.WriteLine(song.ToString());
					}
				}
				else if (menuSelection == 2)
				{
					ISongUtilities addSong = new AddSong();
					addSong.AddSong();
				}
				else if (menuSelection == 3)
				{
					ISongUtilities deleteSong = new DeleteSong();
					deleteSong.DeleteSong();
				}
				else if (menuSelection == 4)
				{
					ISongUtilities editSong = new EditSong();
					editSong.EditSong();
				}
				
				menuSelection = displayMenu();
			}
		}
		private static int displayMenu()
		{
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Welcome to the main menu. Please choose from the following:\n");
			Console.ResetColor();
				Console.WriteLine("1) Show All Songs");
				Console.WriteLine("2) Add a Song");
				Console.WriteLine("3) Delete a Song");
				Console.WriteLine("4) Edit a Song");
				Console.WriteLine("5) Exit");
			int menuSelection = int.Parse(Console.ReadLine());
			return menuSelection;
		}
	}
}
