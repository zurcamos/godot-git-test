using Godot;
using System;

public partial class GameOver : Control
{
	public AudioStreamPlayer audioPlayer;

	[Export] public RichTextLabel scoreText;

	public override void _Ready()
	{
		audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		audioPlayer.Play();
		scoreText.Text = $"Score: {Global.score}";
	}

	public void RETYR()
	{
		GetTree().ChangeSceneToFile("res://Scenes/FlappyBird.tscn");
	}
	public void RETYR2()
	{
		GetTree().Quit();
	}

}
