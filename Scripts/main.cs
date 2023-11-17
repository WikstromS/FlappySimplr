using Godot;

public partial class main : Node
{

	private int _score;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void NewGame()
	{
		_score = 0;

		var player = GetNode<player>("Player");
		var startPosition = GetNode<Marker2D>("StartPosition");
		player.Position = startPosition.Position;

		var hud = GetNode<HUD>("HUD");
		hud.UpdateScore(_score);
	}

	public void UpdateScore()
	{
		_score += 1;
		GetNode<HUD>("HUD").UpdateScore(_score);
	}

}
