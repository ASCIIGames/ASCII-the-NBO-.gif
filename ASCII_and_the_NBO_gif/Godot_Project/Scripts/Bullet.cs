using Godot;
using System;

public class Bullet : Area2D
{
	Vector2 Velocity = new Vector2();

	public override void _PhysicsProcess(float delta)
	{
		Position += Velocity * delta;
	}

}
