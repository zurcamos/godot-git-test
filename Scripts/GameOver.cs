using Godot;
using System;

public partial class GameOver : Control
{
	public AudioStreamPlayer audioPlayer;

	public override void _Ready()
	{
		audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		audioPlayer.Play();
	}

	public void RETYR()
	{
		GD.Print("btn pressed");
		GetTree().ChangeSceneToFile("res://Scenes/FlappyBird.tscn");
	}
	public void RETYR2()
	{
		GetTree().Quit();
	}

}
