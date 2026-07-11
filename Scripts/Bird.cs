using Godot;
using System;

public partial class Bird : CharacterBody2D
{
	private AudioStreamPlayer audioPlayer;
	[Export] public float JumpVelocity;
	[Export] private float gravity;
	private bool holding;

	public override void _Ready()
	{
		Velocity = new Vector2(0, -2000);
		audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsAnythingPressed())
		{
			//GetNode<AnimatedSprite2D>("Wing").animationPlayer.Play("flap");
			if (!holding)
			{
				holding = true;
				velocity.Y = JumpVelocity;
				audioPlayer.PitchScale = (float)GD.RandRange(0.9, 1.1);
				audioPlayer.Play();
			}
		}
		else
		{
			holding = false;
		}
		//TODO: if vel is negative, play flap anim
		velocity.X = 0;
		Velocity = velocity;
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision2D collision = GetSlideCollision(i);
			Node collider = (Node)collision.GetCollider();
			//GD.Print(collider.Name);
			if (collider.IsInGroup("Death"))
			{
				GetTree().ChangeSceneToFile("res://Scenes/GameOver.tscn");
			}
		}
	}
}
