using Godot;
using System;

public class MainMenu : MarginContainer
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	private void _on_start_pressed()
	{
		GetTree().ChangeScene("res://Scenes/Main.tscn");
	}

	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}

}
