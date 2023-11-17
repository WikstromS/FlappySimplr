using Godot;

public partial class tilemap_wall : StaticBody2D
{
	[Signal]
	public delegate void UpdateScoreEventHandler();


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override void _PhysicsProcess(double delta)
    {
        Position += new Vector2(-2, 0);
    }

	public void ScoreAreaHit()
	{
			EmitSignal(SignalName.UpdateScore);
	}
}
