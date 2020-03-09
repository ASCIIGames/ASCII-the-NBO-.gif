using Godot;
using System;

public class RoomsIter : TileMap
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_createRooms(10);

	}


	private int[,] InitLvl()
	{
		int[,] map = new int[10,7];

		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 7; j++)
			{
				if (i == 0 || i == 9 || j == 0 || j == 6)
				{
					map[i, j] = 3;
					Console.WriteLine(map[i,j]);
				}
				else
				{
					map[i, j] = 0;
					Console.WriteLine(map[i,j]);
				}
				
			}
		}
		map[5,4] = 1;

		return map;
	}

	bool CountNeigh(int i, int j, int[,] map)
	{
		int nbN = 0;
		bool res = true;
		
		if(i > 1 && i < 9 && j > 1 && j < 6)
		{
			if (map[i-1, j] != 0)
				nbN += 1;
			if (map[i+1, j] != 0)
				nbN += 1;
			if (map[i, j-1] != 0)
				nbN += 1;
			if (map[i, j+1] != 0)
				nbN += 1;
			if (nbN > 1)
				res = false;
		}
		else
			res = false;
			
		return res;
	}

	bool RngGenH()
	{
		bool res;
		Random rng = new Random();
		if (rng.Next(0, 3) == 1)
			res = false;
		else
			res = true;
			
		return res;
	}
	
	bool RngGenV()
	{
		bool res;
		Random rng = new Random();
		if (rng.Next(0, 3) == 1)
			res = true;
		else
			res = false;
			
		return res;
	}
	
	

	int[,] _createRooms(int nbR)
	{
		int[,] map = InitLvl();
		Console.WriteLine(map[5,4]);
		int n = 0;
		bool res = true;

		
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					if (n < 10)
					{
						if (map[i, j] == 1)
						{   
							map[i, j] = 2;
							if (CountNeigh(i-1, j, map))
								if (RngGenH())
								{
									n += 1;
									map[i - 1, j] = 1;
								}
									
							if (CountNeigh(i+1, j, map))
								if (RngGenH())
								{
									n += 1;
									map[i + 1, j] = 1;
								}
									
							if (CountNeigh(i, j-1, map))
								if (RngGenV())
								{
									n = +1;
									map[i, j - 1] = 1;
								}
									
							if (CountNeigh(i, j+1, map))
								if (RngGenV())
								{
									n += 1;
									map[i, j + 1] = 1;
								}
							Console.WriteLine(n);
						}
					}
					else
					{
						res = false;
					}
						
					

				
				}
			
			
		}
		
		return map;
	}
	
	void DrawMap()
	{

		int[,] rooms = _createRooms(10);
		Random rng = new Random();

		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 7; j++)
			{
				if (rooms[i,j] == 1 || rooms[i,j] == 2)
					SetCell(i*13,j*7,rng.Next(0,7));
			}
		}
	}
	

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
