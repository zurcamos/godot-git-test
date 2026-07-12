using Godot;
using System;

public partial class LogicManager : Node2D
{
	[Export] public AudioStreamPlayer scorePlayer;
	// [Export] private AudioStreamPlayer musicPlayer;
	[Export] public Label scoreText;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// musicPlayer.Play();
		// global = GetNode<Global>("/root/Global");
		Global.score = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public int getScore()
	{
		return Global.score;
	}
	public void updateScore()
	{
		Global.score += 1;
		scoreText.Text = $"Score: {Global.score}";
		scorePlayer.PitchScale = (float)GD.RandRange(0.9, 1.1);
		scorePlayer.Play();
	}
}
