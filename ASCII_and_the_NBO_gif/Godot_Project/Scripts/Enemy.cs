using Godot;
using System;

public class Enemy : KinematicBody2D
{
	[Export] public int Speed = 50;
	
	[Export] public int Health = 100;
	

	public Vector2 Target;
	public Vector2 Velocity;
	
	public bool hit = false;

	public override void _Ready()
	{
		Target = GetNode<KinematicBody2D>("/root/Game/Level/Player").GlobalPosition;
		Target.x += 200;
		Target.y += 150;
	}

	public override void _Process(float delta)
	{
		Target = GetNode<KinematicBody2D>("/root/Game/Level/Player").GlobalPosition;
		Target.x += 200;
		Target.y += 150;
	}

	public override void _PhysicsProcess(float delta)
	{
		Velocity = GlobalPosition.DirectionTo(Target) * Speed;
		if (GlobalPosition.DistanceTo(Target) > 5)
		{
			Velocity = MoveAndSlide(Velocity);
		}
	}
	
	public void KillEnemy() 
	{
		QueueFree();
		Open();
	}
	
	public override void _Input(InputEvent inputEvent)
	{
		Vector2 Adjust = new Vector2 (185, 140);
		
		if (inputEvent.IsActionPressed("attack"))
		{
			GetNode<Sprite>("/root/Game/Level/Player/AttackAnimation/Sword").Position = GetNode<KinematicBody2D>("/root/Game/Level/Player").Position + Adjust; 
			GetNode<AnimationPlayer>("/root/Game/Level/Player/AttackAnimation").Play("attack");
			GetNode<AudioStreamPlayer>("/root/Game/Level/Player/AttackSound").Play();
			if (hit && Health <= 0) 
			{
				KillEnemy();
			}
		}
	}
	
	void Open()
	{
		for (int i = -146; i < 144; i+=15)
			{
				for (int j = -86; j < 84; j += 9)
				{
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 8)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 26);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 24)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 25);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 10)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 30);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 11)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 28);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 12)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 27);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 13)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 29);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 14)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 38);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 15)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 31);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 16)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 35);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 17)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 33);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 18)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 32);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 19)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 34);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 20)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 37);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 21)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 36);
					
					if (GetNode<TileMap>("/root/Game/Level/TileMap").GetCell(i, j) == 22)
						GetNode<TileMap>("/root/Game/Level/TileMap").SetCell(i, j, 39);
				}
			}
	}
	
	private void _on_HurtBox_area_entered(object area)
	{
		hit = true;
		Health -= 50;
	}
	
	private void _on_Interface_InterfaceQuizWon()
	{
		KillEnemy();
	}
	
}
