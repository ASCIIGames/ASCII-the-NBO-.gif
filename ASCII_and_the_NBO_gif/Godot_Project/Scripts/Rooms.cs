using Godot;
using System;



public class Rooms : TileMap
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_createRooms(4,4,0);
		Doors();
		Map();
		Open();
	}
	
	void Open()
	{
		for (int i = -146; i < 144; i+=15)
			{
				for (int j = -86; j < 84; j += 9)
				{
					if (GetCell(i, j) == 8)
						SetCell(i, j, 26);
					
					if (GetCell(i, j) == 24)
						SetCell(i, j, 25);
					
					if (GetCell(i, j) == 10)
						SetCell(i, j, 30);
					
					if (GetCell(i, j) == 11)
						SetCell(i, j, 28);
					
					if (GetCell(i, j) == 12)
						SetCell(i, j, 27);
					
					if (GetCell(i, j) == 13)
						SetCell(i, j, 29);
					
					if (GetCell(i, j) == 14)
						SetCell(i, j, 38);
					
					if (GetCell(i, j) == 15)
						SetCell(i, j, 31);
					
					if (GetCell(i, j) == 16)
						SetCell(i, j, 35);
					
					if (GetCell(i, j) == 17)
						SetCell(i, j, 33);
					
					if (GetCell(i, j) == 18)
						SetCell(i, j, 32);
					
					if (GetCell(i, j) == 19)
						SetCell(i, j, 34);
					
					if (GetCell(i, j) == 20)
						SetCell(i, j, 37);
					
					if (GetCell(i, j) == 21)
						SetCell(i, j, 36);
					
					if (GetCell(i, j) == 22)
						SetCell(i, j, 39);
				}
			}
	}
	
	public void Doors()
	{
		int nbN;
		
		for (int i = -146; i < 144; i+=15)
		{
			for (int j = -86; j < 84; j+= 9)
			{
				nbN = NbNeighbours(i,j);
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
						SetCell(i,j,24);
						
					else if (nbN == 3 && GetCell(i+15,j) != -1 && GetCell(i-15,j) != -1 
							 && GetCell(i,j+9) != -1)
						SetCell(i,j,17);
						
					else if (nbN == 3 && GetCell(i+15,j) != -1 && GetCell(i-15,j) != -1 
							 && GetCell(i,j-9) != -1)
						SetCell(i,j,19);
						
					else if (nbN == 3 && GetCell(i+15,j) != -1 && GetCell(i,j-9) != -1 
							 && GetCell(i,j+9) != -1)
						SetCell(i,j,12);
						
					else if (nbN == 3 && GetCell(i-15,j) != -1 && GetCell(i,j-9) != -1 
							 && GetCell(i,j+9) != -1)
						SetCell(i,j,21);
						
					else if (nbN == 4 && GetCell(i+15,j) != -1 && GetCell(i-15,j) != -1 
							 && GetCell(i,j+9) != -1 && GetCell(i,j-9) != -1)
						SetCell(i,j,18);
				}
			}		
		}
	}
	
	void _createRooms(int x, int y, int nbRoom)
	{
		int nb = nbRoom;
		SetCell(x,y,23);

		if (CountNeighbours(x - 15, y) && Hgeneration() && nb < 5)
		{
			nb++;
			if (nb < 10)
				_createRooms(x - 15, y, nbRoom+1);
		}

		if (CountNeighbours(x,y - 9) && generation() && nb < 5)
		{
			nb++;
			if (nb < 10)
				_createRooms(x, y - 9, nbRoom+1);
		}

		if (CountNeighbours(x + 15, y) && Hgeneration() && nb < 5)
		{
			nb++;
			if (nb < 10)
				_createRooms(x + 15, y, nbRoom+1);
		}

		if (CountNeighbours(x,y + 9) && generation() && nb < 5)
		{
			nb++;
			if (nb < 10)
				_createRooms(x, y + 9, nbRoom+1);
		}
		
		else if(nbRoom < 11)
		{
			_createRooms(x,y, nbRoom+1);
		}
	}


	int NbNeighbours(int x, int y)
	{
		int nbNeighbours = 0;

		if (GetCell(x - 15, y) != -1)
			nbNeighbours++;

		if (GetCell(x + 15, y) != -1)
			nbNeighbours++;

		if (GetCell(x, y - 9) != -1)
			nbNeighbours++;

		if (GetCell(x, y + 9) != -1)
			nbNeighbours++;
		
		return nbNeighbours;
	}

	bool CountNeighbours(int x, int y)
	{
		int nbNeighbours = 0;
		
		if (GetCell(x - 15, y) != -1)
			nbNeighbours++;

		if (GetCell(x + 15, y) != -1)
			nbNeighbours++;

		if (GetCell(x, y - 9) != -1)
			nbNeighbours++;

		if (GetCell(x, y + 9) != -1)
			nbNeighbours++;
		
		if (nbNeighbours == 1)
			return true;
		
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

	void _on_CheckBox_toggled(bool buttonPressed) //open or close the doors
	{
		if (buttonPressed)
		{
			for (int i = -146; i < 144; i+=15)
			{
				for (int j = -86; j < 84; j += 9)
				{
					if (GetCell(i, j) == 8)
						SetCell(i, j, 26);
					
					if (GetCell(i, j) == 24)
						SetCell(i, j, 25);
					
					if (GetCell(i, j) == 10)
						SetCell(i, j, 30);
					
					if (GetCell(i, j) == 11)
						SetCell(i, j, 28);
					
					if (GetCell(i, j) == 12)
						SetCell(i, j, 27);
					
					if (GetCell(i, j) == 13)
						SetCell(i, j, 29);
					
					if (GetCell(i, j) == 14)
						SetCell(i, j, 38);
					
					if (GetCell(i, j) == 15)
						SetCell(i, j, 31);
					
					if (GetCell(i, j) == 16)
						SetCell(i, j, 35);
					
					if (GetCell(i, j) == 17)
						SetCell(i, j, 33);
					
					if (GetCell(i, j) == 18)
						SetCell(i, j, 32);
					
					if (GetCell(i, j) == 19)
						SetCell(i, j, 34);
					
					if (GetCell(i, j) == 20)
						SetCell(i, j, 37);
					
					if (GetCell(i, j) == 21)
						SetCell(i, j, 36);
					
					if (GetCell(i, j) == 22)
						SetCell(i, j, 39);
				}
			}
		}
		if (!buttonPressed)
		{
			for (int i = -146; i < 144; i+=15)
			{
				for (int j = -86; j < 84; j += 9)
				{
					if (GetCell(i, j) == 26)
						SetCell(i, j, 8);
					
					if (GetCell(i, j) == 25)
						SetCell(i, j, 24);
					
					if (GetCell(i, j) == 30)
						SetCell(i, j, 10);
					
					if (GetCell(i, j) == 28)
						SetCell(i, j, 11);
					
					if (GetCell(i, j) == 27)
						SetCell(i, j, 12);
					
					if (GetCell(i, j) == 29)
						SetCell(i, j, 13);
					
					if (GetCell(i, j) == 38)
						SetCell(i, j, 14);
					
					if (GetCell(i, j) == 31)
						SetCell(i, j, 15);
					
					if (GetCell(i, j) == 35)
						SetCell(i, j, 16);
					
					if (GetCell(i, j) == 33)
						SetCell(i, j, 17);
					
					if (GetCell(i, j) == 32)
						SetCell(i, j, 18);
					
					if (GetCell(i, j) == 34)
						SetCell(i, j, 19);
					
					if (GetCell(i, j) == 37)
						SetCell(i, j, 20);
					
					if (GetCell(i, j) == 36)
						SetCell(i, j, 21);
					
					if (GetCell(i, j) == 39)
						SetCell(i, j, 22);
				}
			}
		}
	}
	

	public void Map()
	{
		int x = 0;
		int y;
		
		for (int i = -146; i < 144; i += 15)
		{
			y = 0;
			x += 1;
			for (int j = -86; j < 84; j += 9)
			{
				y += 1;
				if (GetCell(i, j) != -1)
				{
					//Console.WriteLine(x + y);
					GetNode<TileMap>("/root/Game/Level/CanvasLayer/Map").SetCell(x, y, 0);
				}
			}
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 	public override void _Process(float delta)
	{
		
	}
}




