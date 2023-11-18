using System;
using Godot;

public partial class tilemap_wall : Area2D
{
	[Signal]
	public delegate void UpdateScoreEventHandler();
	[Signal]
	public delegate void WallHitEventHandler();


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var rng = new RandomNumberGenerator();
		Position = new Vector2(1200, rng.RandiRange(220, 500));
	}

    public override void _PhysicsProcess(double delta)
    {
        Position += new Vector2(-2, 0);
    }

	public void ScoreAreaHit()
	{
		EmitSignal(SignalName.UpdateScore);
	}

	private void OnBodyEntered(Node2D body)
	{
		EmitSignal(SignalName.WallHit);
	}
}
