using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export]
	public int Speed = 80; // How fast the player will move (pixels/sec).
	
	[Export]
	public int max_health = 99; 
	
	[Signal]
	delegate void Hit();
	
	[Signal]
	delegate void Moving();	
	
	[Signal]
	delegate void health_updated (int health);
	
	[Signal]
	delegate void killed();
	
	public Vector2 Adjust = new Vector2 (185, 140);
	
	public int _health = 99;
	
	public void damage(int amount) 
	{
		_health = _health - amount;
		EmitSignal("health_updated", _health);
		if(_health <= 0) 
		{
			Speed = 0;
			EmitSignal("killed");
		}
	}
	
	
	public override void _Ready()
	{
		var health = max_health;
	}
	
	
	public override void _Process(float delta)
	{
		var velocity = new Vector2(); // The player's movement vector.
	
		if (Input.IsActionPressed("ui_right"))
		{
			velocity.x += 1;
		}
	
		if (Input.IsActionPressed("ui_left"))
		{
			velocity.x -= 1;
		}
	
		if (Input.IsActionPressed("ui_down"))
		{
			velocity.y += 1;
		}
	
		if (Input.IsActionPressed("ui_up"))
		{
			velocity.y -= 1;
		}
	
	
		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
		}
		Position += velocity * delta;
		Position = new Vector2(Position.x, Position.y);
		
		GetNode<Sprite>("/root/Game/Level/Player/AttackAnimation/Sword").Position = GetNode<KinematicBody2D>("/root/Game/Level/Player").Position + Adjust;

		if (Input.IsActionPressed("ui_up") || Input.IsActionPressed("ui_down") ||
			Input.IsActionPressed("ui_left") || Input.IsActionPressed("ui_right"))
		{
			EmitSignal("Moving");
		}
		
		MoveAndSlide(velocity, new Vector2(0, -1));
	}
	
	private void _on_Interface_Quiz()
	{
		Speed = 0;
	}
	
	private void _on_Interface_QuizEnded()
	{
		Speed = 100;
	}
	
	public bool hurt = false;
	
	private void _on_HurtTimer_timeout()
	{
		if (hurt) 
		{
			GetNode<AudioStreamPlayer>("HurtSound").Play();
			damage(33);
			hurt = false;
		}
	}
	
	private void _on_Area2D_area_entered(object area)
	{
		GetNode<Timer>("Area2D/HurtTimer").Start();
		hurt = true;
	}
	
	private void _on_Area2D_area_exited(object area)
	{
		hurt = false;
	}
	

}



