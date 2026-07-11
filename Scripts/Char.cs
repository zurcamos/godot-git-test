using Godot;
using System;

public partial class Char : CharacterBody2D
{
	[Export] public float JumpVelocity = -400.0f;
	private int wasPressed = 0;
	private int jumping = 0;
	private float jumpAng = 0;
	[Export] private Label label;
	private Vector2 vel;
	private float groundFric = .18f;
	private float airFric = .05f;
	/*
	/// <summary>
    /// Force to apply when balancing player.
    /// </summary>
    public float balanceForce = 0.3f;
    /// <summary>
    /// Maximum absolute angle of player in balance. Outside this angle player will actively try to balance.
    /// </summary>
    public float maxBalancedAngle = 7.2f;

    [Header("Turn")]
    /// <summary>
    /// Maximum turn speed to rotate player when turning.
    /// </summary>
    public float maxTurnSpeed = 280;
    /// <summary>
    /// Time it takes to reach maximum turn speed.
    /// </summary>
    public float lerpTurnTime = 0.5f;
    /// <summary>
    /// Maximum angle that player can turn before stopping.
    /// </summary>
    public float maxTurnAngle = 53.5f;
	*/
	public override void _PhysicsProcess(double delta)
	{
		vel = Velocity;

		if (!IsOnFloor())
		{
			vel += GetGravity() * (float)delta;
		}
		if (Input.IsActionPressed("left"))
		{
			if (RotationDegrees >= -60)
			{
				RotationDegrees -= 10;
			}
			else
			{
				RotationDegrees = -60;
			}
			wasPressed = 2;
		}
		else if (Input.IsActionPressed("right"))
		{
			if (RotationDegrees <= 60)
			{
				RotationDegrees += 10;
			}
			else
			{
				RotationDegrees = 60;
			}
			wasPressed = 2;
		}
		RotationDegrees = Mathf.Lerp(RotationDegrees, 0, 0.1f);

		if (wasPressed == 0 && IsOnFloor() && jumping == 0)
		{
			GD.Print("jump");
			jumping = 3;
		}
		if (jumping > 2)
		{
			vel = Vector2.FromAngle(180) * 200;
		}
		if (jumping > 0)
		{
			jumping--;
		}
		wasPressed--;

		label.Text = "X: " + vel.X + ", Y: " + vel.Y;//$"Angle: {Mathf.Round(Mathf.RadToDeg(Rotation))}°";
													 //label.Position = new Vector2(vel.X / 10, vel.Y / 10);
		label.RotationDegrees = -RotationDegrees;
		if (IsOnFloor())
		{
			vel.X *= groundFric * (float)delta;
		}
		else
		{
			vel.X *= airFric * (float)delta;
		}
		Velocity = vel;
		MoveAndSlide();

	}

}
