using Godot;
using System;

public partial class ScoreArea : Area2D
{
	[Signal]
	public delegate void ScoreAreaHitEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(CharacterBody2D body)
	{
			EmitSignal(SignalName.ScoreAreaHit);
	}
}
