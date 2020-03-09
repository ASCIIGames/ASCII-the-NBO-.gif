using Godot;
using System;



public class Rooms : TileMap
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_createRooms(4,4,0);
		doors();
	}
	
	void doors()
	{
		int nbN;
		
		for (int i = -146; i < 144; i+=15)
		{
			for (int j = -86; j < 84; j+= 9)
			{
				nbN = nbNeighbours(i,j);
				Console.WriteLine((i,j));
				if (GetCell(i,j) != -1)
				{
					if (nbN == 1 && GetCell(i-15,j) != -1)
						SetCell(i,j,14);
						
					else if (nbN == 1 && GetCell(i+15,j) != -1)
						SetCell(i,j,10);
						
					else if (nbN == 1 && GetCell(i,j-9) != -1)
						SetCell(i,j,22);
						
					else if (nbN == 1 && GetCell(i,j+9) != -1)
						SetCell(i,j,8);
						
					else if (nbN == 2 && GetCell(i+15,j) != -1 && GetCell(i-15,j) != -1)
						SetCell(i,j,16);
						
					else if (nbN == 2 && GetCell(i+15,j) != -1 && GetCell(i,j+9) != -1)
						SetCell(i,j,11);
						
					else if (nbN == 2 && GetCell(i-15,j) != -1 && GetCell(i,j-9) != -1)
						SetCell(i,j,20);
						
					else if (nbN == 2 && GetCell(i+15,j) != -1 && GetCell(i,j-9) != -1)
						SetCell(i,j,13);
						
					else if (nbN == 2 && GetCell(i-15,j) != -1 && GetCell(i,j+9) != -1)
						SetCell(i,j,15);
						
					else if (nbN == 2 && GetCell(i,j+9) != -1 && GetCell(i,j-9) != -1)
						SetCell(i,j,9);
						
					else if (nbN == 3 && GetCell(i+15,j) != -1 && GetCell(i-15,j) != -1 && GetCell(i,j+9) != -1)
						SetCell(i,j,17);
						
					else if (nbN == 3 && GetCell(i+15,j) != -1 && GetCell(i-15,j) != -1 && GetCell(i,j-9) != -1)
						SetCell(i,j,19);
						
					else if (nbN == 3 && GetCell(i+15,j) != -1 && GetCell(i,j-9) != -1 && GetCell(i,j+9) != -1)
						SetCell(i,j,12);
						
					else if (nbN == 3 && GetCell(i-15,j) != -1 && GetCell(i,j-9) != -1 && GetCell(i,j+9) != -1)
						SetCell(i,j,21);
						
					else if (nbN == 4 && GetCell(i+15,j) != -1 && GetCell(i-15,j) != -1 && GetCell(i,j+9) != -1 && GetCell(i,j-9) != -1)
						SetCell(i,j,18);
				}
			}		
		}
	}
	
	void _createRooms(int x, int y, int nbRoom)
	{
		Random rng = new Random();
		int nb = nbRoom;
		Console.WriteLine((x,y));
		SetCell(x,y,23);

		if (countNeighbours((x-1)-14,y) && Hgeneration() && nb < 10)
		{
			nb++;
			if (nb < 10)
				_createRooms((x-1)-14, y, nbRoom+1);
		}

		if (countNeighbours(x,(y-1)-8) && generation() && nb < 10)
		{
			nb++;
			if (nb < 10)
				_createRooms(x, (y-1)-8, nbRoom+1);
		}

		if (countNeighbours((x+1)+14,y) && Hgeneration() && nb < 10)
		{
			nb++;
			if (nb < 10)
				_createRooms((x+1)+14, y, nbRoom+1);
		}

		if (countNeighbours(x,(y+1)+8) && generation() && nb < 10)
		{
			nb++;
			if (nb < 10)
				_createRooms(x, (y+1)+8, nbRoom+1);
		}
		
		else if(nbRoom < 11)
		{
			_createRooms(x,y, nbRoom+1);
		}
	}
	
	
	int nbNeighbours(int x, int y)
	{
		int nbN = 0;
		
		if (GetCell(x-15, y) != -1)
			nbN++;

		if (GetCell(x+15, y) != -1)
			nbN++;

		if (GetCell(x, y-9) != -1)
			nbN++;

		if (GetCell(x, y+9) != -1)
			nbN++;
			
		return nbN;
	}

	bool countNeighbours(int x, int y)
	{
		int nbNeighbours = 0;
		
		if (GetCell((x-1)-14, y) != -1)
			nbNeighbours++;

		if (GetCell((x+1)+14, y) != -1)
			nbNeighbours++;

		if (GetCell(x, (y-1)-8) != -1)
			nbNeighbours++;

		if (GetCell(x, (y+1)+8) != -1)
			nbNeighbours++;
		
		if (nbNeighbours == 1)
			return true;
		else
			return false;
	}

	bool generation()
	{
		bool res;
		Random rng = new Random();
		if (rng.Next(0, 3) == 1)
			res = true;
		else
			res = false;
			
		return res;
	}
	
	bool Hgeneration()
	{
		bool res;
		Random rng = new Random();
		if (rng.Next(0, 3) == 1)
			res = false;
		else
			res = true;
			
		return res;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 	public override void _Process(float delta)
 	{
		
	}
}
