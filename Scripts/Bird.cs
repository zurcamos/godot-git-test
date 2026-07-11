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

		Velocity = velocity;
		MoveAndSlide();
	}

	public void _OnBodyEntered(Node2D collision)
	{
		if (collision is RigidBody2D)
		{
			GetTree().ReloadCurrentScene();
		}
	}

}
