using Godot;
using System;

public partial class PipeMovement : RigidBody2D
{
	[Export] private float offset;
	[Export] private float minMaxOffset;

	[Export] private float speed;
	[Export] private Area2D score { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddToGroup("Death");
		offset = (float)GD.RandRange(-minMaxOffset, minMaxOffset);
		Vector2 pos = Position;
		pos.Y = offset;
		Position = pos;
		GetNode<Area2D>("%killZone").Connect("body_entered", new Callable(this, "KILLME"));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		LinearVelocity = new Vector2(speed, 0);

		// MoveAndSlide();
	}

	public void KILLME()
	{
		GD.Print("I'm dead skullemoji");
		QueueFree();
	}
}
