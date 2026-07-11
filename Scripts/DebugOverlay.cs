using Godot;
using System;

public partial class DebugOverlay : Node2D
{
	[Export] private CharacterBody2D targ;
	// Called when the node enters the scene tree for the first time.
	public override void _Process(double delta)
	{
		if (targ == null) return;
		GlobalPosition = targ.GlobalPosition;
		QueueRedraw();
	}
	public override void _Draw()
	{
		if (targ == null) return;
		// If the character isn't moving, don't draw anything
		if (targ.Velocity.LengthSquared() < 0.1f) return;

		// Draws perfectly on top, globally aligned, and unaffected by parent rotation
		DrawLine(Vector2.Zero, targ.Velocity * 0.2f, Colors.Yellow, 4.0f);
		DrawCircle(targ.Velocity * 0.2f, 5.0f, Colors.Orange);
	}
}
