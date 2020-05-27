using Godot;
using System;

public class Win : CanvasLayer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Signal]
	delegate void RespawnWin();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	private void _on_Respawn_pressed()
	{
		EmitSignal("RespawnWin");
	}


	private void _on_Quit_pressed()
	{
		GetTree().Quit();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}



