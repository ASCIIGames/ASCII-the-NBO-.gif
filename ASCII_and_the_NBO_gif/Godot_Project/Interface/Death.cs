using Godot;
using System;

public class Death : CanvasLayer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Signal]
	delegate void Respawn();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	private void _on_Button_pressed()
	{
		EmitSignal("Respawn");
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




