using Godot;
using System;

public partial class PipeSpawner : Node2D
{
	[Export] public PackedScene pipe { get; set; }
	private float spawnTimer;
	private LogicManager logicManager;
	[Export] public float spawnTime = 3;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		logicManager = GetTree().GetFirstNodeInGroup("LogicManager") as LogicManager;
		spawnTimer = spawnTime;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		spawnTimer += (float)delta;
		if (spawnTimer >= spawnTime)
		{
			float scaling = Math.Clamp((float)logicManager.getScore() / 10, 1, 3);
			spawnTime = 3 / scaling;
			spawnTimer = (float)GD.RandRange(0, 1.0 / scaling);
			Node2D newPipe = pipe.Instantiate<Node2D>();
			newPipe.GlobalPosition = GlobalPosition;
			AddChild(newPipe);
		}
	}
}
