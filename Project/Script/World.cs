using Godot;
using System;

public class World : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export(PropertyHint.Range, "0,100,5")]
	int iniChance;
	
	[Export(PropertyHint.Range, "0,8,1")]
	int birthLimit;
	
	[Export(PropertyHint.Range, "0,8,1")]
	int deathLimit;
	
	[Export(PropertyHint.Range, "1,10,1")]
	int numR;
	
	[Export]
	public Godot.TileMap Top, Bot;
	[Export]
	public int TopTile, BotTile;
	
	int width, height;
	
	
	Vector2[] BoundsInt;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
