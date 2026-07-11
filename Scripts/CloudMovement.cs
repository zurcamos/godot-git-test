using Godot;
using System;

public partial class CloudMovement : Sprite2D
{
	[Export] public float baseSpeed;
	[Export] public float speedOffset;
	private float speed;
	[Export] public float scaleOffset;
	[Export] public float yOffset;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		speed = baseSpeed + (float)GD.RandRange(-speedOffset, speedOffset);
		float scaleChange = (float)GD.RandRange(1 - scaleOffset, 1 + scaleOffset);
		Scale = new Vector2(scaleChange, scaleChange);
		Vector2 pos = Position;
		pos.Y = (float)GD.RandRange(yOffset, -yOffset);
		Position = pos;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 pos = Position;
		pos.X += speed * (float)delta;
		Position = pos;
	}
	public void KILLME()
	{
		QueueFree();
	}
}
