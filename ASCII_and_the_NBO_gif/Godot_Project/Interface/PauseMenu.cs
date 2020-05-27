using Godot;
using System;

public class PauseMenu : CanvasLayer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	private void _on_Quit_pressed()
	{
		GetTree().Quit();
	}

	public bool ismusicOn = true;

	private void _on_MusicButton_pressed()
	{
		if(ismusicOn) 
		{
			GetNode<AudioStreamPlayer>("/root/Game/Music").Stop(); 
			ismusicOn = false;
		}
		else 
		{
			GetNode<AudioStreamPlayer>("/root/Game/Music").Play();
			ismusicOn = true;
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

