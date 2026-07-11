using Godot;
using System;

public partial class GameOver : Control
{
	public void RETYR()
	{
		GetTree().ChangeSceneToFile("res://Scenes/FlappyBird.tscn");
	}

}
