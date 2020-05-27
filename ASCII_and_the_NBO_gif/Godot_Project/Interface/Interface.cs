using Godot;
using System;

public class Interface : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Signal]
	public delegate void Quiz();
	
	[Signal]
	public delegate void QuizEnded();
	
	[Signal]
	public delegate void InterfaceQuizWon();
	
	[Signal]
	public delegate void RespawnInterface();
	
	public double heal;
	
	public bool inpause = false;
	public bool inQuiz = false;
	
	public override void _Input(InputEvent inputEvent)
	{
		if (inputEvent.IsActionPressed("quiz_launch") && !inQuiz)
		{
			inQuiz = true;
			GetNode<Control>("Quiz/button").Show();
			EmitSignal(nameof(Quiz));
			GetTree().Paused = true;
		}
		if (inputEvent.IsActionPressed("ui_cancel"))
		{
			if(inpause)
			{
				GetNode<Control>("PauseMenu/Control").Hide();
				inpause = false;
				GetTree().Paused = false;
			}
			else
			{
				GetNode<Control>("PauseMenu/Control").Show();
				inpause = true;;
				GetTree().Paused = true;
			}
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Control>("Quiz/button").Hide();
		GetNode<Control>("Death/RespawnMenu").Hide();
		GetNode<Control>("PauseMenu/Control").Hide();
		GetNode<Control>("Win/RespawnMenu").Hide();
		heal = GetNode<TextureProgress>("/root/Game/Interface/CanvasLayer/HealthBar/TextureProgress").Value;
		
	}
	
	private void _on_Quiz_End()
	{
		inQuiz = false;
		GetNode<Control>("Quiz/button").Hide();
		GetTree().Paused = false;
		EmitSignal(nameof(QuizEnded));
	}
	
	private void _on_Player_health_updated(double health)
	{
		GetNode<TextureProgress>("/root/Game/Interface/CanvasLayer/HealthBar/TextureProgress").Value = health;
	}
	
	private void _on_Quiz_QuizWon()
	{
		inQuiz = false;
		GetTree().Paused = false;
		EmitSignal("InterfaceQuizWon");
	}

	private void _on_Player_killed()
	{
		GetNode<Control>("Death/RespawnMenu").Show();
	}
	
	private void _on_Death_Respawn()
	{
		EmitSignal("RespawnInterface");
	}
	
	private void _on_Win_RespawnWin()
	{
		EmitSignal("RespawnInterface");
	}
	
	private void _on_Game_Win()
	{
		GetNode<Control>("Win/RespawnMenu").Show();
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}

