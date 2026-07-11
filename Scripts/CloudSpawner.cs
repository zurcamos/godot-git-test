using Godot;
using System;

public partial class CloudSpawner : Node2D
{
	[Export] public PackedScene cloud {get; set;}
	private float spawnTimer;
	[Export] public float spawnTimeMin = 0.5f;
	[Export] public float spawnTimeMax = 2.5f;
	private float spawnTime;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spawnCloud();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		spawnTimer+=(float)delta;
		if (spawnTimer>=spawnTime) {
			spawnCloud();
		}
	}

	public void spawnCloud() {
		spawnTimer = 0;
		spawnTime = (float)GD.RandRange(spawnTimeMin,spawnTimeMax);
		Node2D newCloud = cloud.Instantiate<Node2D>();
		newCloud.GlobalPosition = GlobalPosition;
		AddChild(newCloud);
	}
}
