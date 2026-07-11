using Godot;
using System;

public partial class PipeMovement : RigidBody2D
{
	[Export] private float offset;
	[Export] private float minMaxOffset;

	[Export] private float speed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		offset = (float)GD.RandRange(-minMaxOffset,minMaxOffset);
		Vector2 pos = Position;
		pos.Y = offset;
		Position = pos;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 pos = Position;
		pos.X += speed;
		Position = pos;
	}
}
