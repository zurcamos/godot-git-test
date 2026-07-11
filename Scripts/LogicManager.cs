using Godot;
using System;

public partial class LogicManager : Node2D
{
	[Export] private AudioStreamPlayer audioPlayer;
	[Export] public Label scoreText;
	private int score = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public int getScore()
	{
		return score;
	}
	public void updateScore()
	{
		score += 1;
<<<<<<< Updated upstream
		scoreText.Text = $"Score: {score}😘";
=======
		scoreText.Text = $"Score: {score}";
		audioPlayer.PitchScale = (float)GD.RandRange(0.9,1.1);
		audioPlayer.Play();
>>>>>>> Stashed changes
	}
}
