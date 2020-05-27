using Godot;
using System;
using System.Linq;
using Object = Godot.Object;

public class Camera : Node
{
	[Export]
	public PackedScene Enemy;
		
	[Signal]
	delegate void Win();

	
	public Vector2 playerGridPos;
	public Vector2[] cleanedRooms = new Vector2[50];
	public int k = 0;
	public int nbKills = 2;
	public int nbRooms = 0;

	public override void _Ready()
	{
		playerGridPos = player_grid_pos();
		Vector2 windowSize = OS.WindowSize;
		Vector2 screen = new Vector2(Mathf.Floor(windowSize.x*0.235f), Mathf.Floor(windowSize.y*0.24f));
		Vector2 initScreen = new Vector2(-57,-13);
		
		var camera = GetNode<Camera2D>("Camera");
		camera.Zoom = new Vector2(0.235f,0.24f);
		camera.Offset = initScreen + screen / 2;
		nbRooms = CountRooms();
	}

	void update_cam()
	{
		Vector2 windowSize = OS.WindowSize;
		Vector2 screen = new Vector2(Mathf.Floor(windowSize.x*0.235f), Mathf.Floor(windowSize.y*0.24f));
		Vector2 adjust = new Vector2(1, 1);
		Vector2 adjust2 = new Vector2(-57,-13);
		
		
		var camera = GetNode<Camera2D>("Camera");
		var newPlayerGridPos = player_grid_pos();
		if (newPlayerGridPos != playerGridPos)
		{
			//Console.WriteLine(GetNode<TileMap>("/root/Game/Level/CanvasLayer/Map").GetCell(2,2));
			
			newPlayerGridPos = player_grid_pos();
			playerGridPos = newPlayerGridPos;
			camera.Offset = (player_grid_pos() + adjust) * screen + screen / 2 + adjust2;
			
			GetNode<TileMap>("/root/Game/Level/CanvasLayer/Map").SetCell(2, 3, 1);

			if (!cleanedRooms.Contains(playerGridPos))
			{
				cleanedRooms[k] = playerGridPos;
				k += 1;
				GetNode<Timer>("/root/Game/Timer").Start();
			}
		}
	}

	Vector2 player_grid_pos()
	{
		Vector2 windowSize = OS.WindowSize;
		Vector2 screen = new Vector2(windowSize.x*0.235f, windowSize.y*0.24f);
		
		var pos = GetNode<KinematicBody2D>("Level/Player").Position - screen / 2;
		var x = Mathf.FloorToInt(pos.x / (OS.WindowSize.x*0.235f));
		var y = Mathf.FloorToInt(pos.y / (OS.WindowSize.y*0.24f));
		
		Vector2 res = new Vector2(x, y);
		//Console.WriteLine(pos);

		return res;
	}
	
	void Close()
	{
		for (int i = -146; i < 144; i+=15)
		{
			for (int j = -86; j < 84; j += 9)
			{
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 26)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 8);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 25)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 24);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 30)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 10);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 28)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 11);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 27)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 12);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 29)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 13);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 38)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 14);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 31)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 15);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 35)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 16);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 33)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 17);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 32)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 18);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 34)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 19);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 37)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 20);
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 36)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 21);
				}

				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 39)
				{
					GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 22);
				}
			}
		}
	}
	
	int CountRooms()
	{
		for (int i = -146; i < 144; i+=15)
		{
			for (int j = -86; j < 84; j += 9)
			{
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 26)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 25)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 30)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 28)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 27)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 29)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 38)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 31)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 35)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 33)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 32)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 34)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 37)
				{
					nbRooms += 1;
				}
				
				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 36)
				{
					nbRooms += 1;
				}

				if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 39)
				{
					nbRooms += 1;
				}
					
			}
		}

		return nbRooms;
	}

	void summonMobs()
	{
		Vector2 windowSize = OS.WindowSize;
		Vector2 screen = new Vector2(windowSize.x*0.235f, windowSize.y*0.24f);
		
		var enemyInstance = (KinematicBody2D)Enemy.Instance();
		AddChild(enemyInstance);

		enemyInstance.Position = GetNode<Camera2D>("/root/Game/Camera").Offset + screen / 2;
	}
	
	void _on_Timer_timeout()
	{
		Close();
		summonMobs();
		GetNode<Timer>("/root/Game/Timer").Stop();
		if (nbKills == nbRooms)
		{
			EmitSignal("Win");
		}
		nbKills += 1;
		
	}
	
	private void _on_Interface_RespawnInterface()
	{
		GetTree().ChangeScene("res://Scenes/Main.tscn");
	}
}







