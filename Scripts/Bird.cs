using Godot;
using System;

public partial class Bird : CharacterBody2D
{
	[Export] public float JumpVelocity;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsAnythingPressed())
		{
			velocity.Y = JumpVelocity;
		}
		velocity.X = 0;
		Velocity = velocity;
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision2D collision = GetSlideCollision(i);
			Node collider = (Node)collision.GetCollider();
			GD.Print(collider.Name);
			if (collider.IsInGroup("Death"))
			{
				GetTree().ReloadCurrentScene();
			}
		}
	}
}
