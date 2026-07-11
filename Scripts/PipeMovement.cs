using Godot;
using System;

public partial class PipeMovement : RigidBody2D
{
	[Export] private float offset;
	[Export] private float minMaxOffset;

	[Export] private float speed;
	[Export] private Area2D score { get; set; }

	private LogicManager logicManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		logicManager = GetTree().GetFirstNodeInGroup("LogicManager") as LogicManager;
		AddToGroup("Death");
		offset = -minMaxOffset;//(float)GD.RandRange(minMaxOffset, -minMaxOffset);
		Vector2 pos = Position;
		pos.Y = offset;
		Position = pos;
		speed = speed * scoreMult(logicManager.getScore());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		LinearVelocity = new Vector2(speed, 0);

		// MoveAndSlide();
	}
	private float scoreMult(int score)
	{
		score = Math.Max(score, 1);
		return Math.Clamp((float)score / 10, 1, 3);
	}
	public void KILLME()
	{
		QueueFree();
	}
	public void _OnScoreAreaEntered(Node2D collision)
	{
		if (collision is Bird)
		{
			GD.Print("Scored");
			logicManager.updateScore();
		}
	}
}
