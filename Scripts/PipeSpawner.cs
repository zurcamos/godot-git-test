using Godot;
using System;

public partial class PipeSpawner : Node2D
{
	[Export] public Area2D deathzone {get; set;}
	[Export] public PackedScene pipe {get; set;}
	private float spawnTimer;
	[Export] public float spawnTime = 3;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		spawnTimer += (float)delta;
		if (spawnTimer>=spawnTime) {
			spawnTimer = 0;
			Node2D newPipe = pipe.Instantiate<Node2D>();
			newPipe.GlobalPosition = GlobalPosition;
			AddChild(newPipe);
		}
	}
}
