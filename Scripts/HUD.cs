using Godot;

public partial class HUD : CanvasLayer
{

	[Signal]
	public delegate void StartGameEventHandler();

	public void UpdateScore(int score)
	{
		GetNode<Label>("ScoreLabel").Text = $"Score : {score.ToString()}";
		
	}
	
	private void OnStartButtonPressed()
	{
		GetNode<Button>("StartButton").Hide();
		EmitSignal(SignalName.StartGame);
	}

}
