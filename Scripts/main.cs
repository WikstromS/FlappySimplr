using Godot;

public partial class main : Node
{

	[Export]
	public PackedScene tilemap_wall_scene {get;set;}

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

		// instantiate a new player entity everytime the game starts
		// this gets rid of the physics being applied when "dead" 

		var playerScene = (PackedScene)ResourceLoader.Load("res://Scenes/player.tscn");
		var newPlayer = playerScene.Instantiate();
		AddChild(newPlayer);

		var player = GetNode<player>("Player");
		var startPosition = GetNode<Marker2D>("PlayerStartPosition");
		player.Start(startPosition.Position);

		var hud = GetNode<HUD>("HUD");
		hud.UpdateScore(_score);

		hud.ShowMessage("Onnea matkaan!");

		GetNode<Timer>("WallTimer").Start();
	}

	public void GameOver()
	{
		GetNode<player>("Player").Die();
		GetNode<HUD>("HUD").ShowGameOver();
		GetNode<Timer>("WallTimer").Stop();

	}

	public void UpdateScore()
	{
		_score++;
		GetNode<HUD>("HUD").UpdateScore(_score);
	}

	public void OnWallTimerTimeOut()
	{
		// new instance of tilemap_wall
		tilemap_wall wall = tilemap_wall_scene.Instantiate<tilemap_wall>();

		AddChild(wall);
		wall.Connect("UpdateScore", new Callable(this, MethodName.UpdateScore) );
		wall.Connect("WallHit", new Callable(this, MethodName.GameOver) );

	}

}
