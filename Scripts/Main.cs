using Godot;
using System;

public partial class Main : Node2D
{
	private CharacterBody2D sprite;
	private bool wasPressed = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("hello world");
		sprite = GetNode<CharacterBody2D>("%TestSprite");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("left"))
		{
			sprite.RotationDegrees -= 10;
			wasPressed = true;
		}
		else if (Input.IsActionPressed("right"))
		{
			sprite.RotationDegrees += 10;
			wasPressed = true;
		}
		else if (wasPressed)
		{
			jump();
		}
		wasPressed = false;
		sprite.MoveAndSlide();
	}
	private void jump()
	{
		sprite.Position += new Vector2(0, -100);
	}
}
/*
[Export] 
    public CharacterBody2D TargetBody { get; set; }
Vector2 dir = Input.GetVector("left", "right", "up", "down");
*/