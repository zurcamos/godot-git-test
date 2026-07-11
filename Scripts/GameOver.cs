using Godot;
using System;

public partial class GameOver : Control
{

	public void RETYR()
	{
		GD.Print("btn pressed");
		GetTree().ChangeSceneToFile("res://Scenes/FlappyBird.tscn");
	}

}
