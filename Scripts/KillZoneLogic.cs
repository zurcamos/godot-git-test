using Godot;
using System;

public partial class KillZoneLogic : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D other) {
		if (other.IsInGroup("Death")) {
			PipeMovement pipe = other as PipeMovement;

			if (pipe!=null) {
				pipe.KILLME();
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
