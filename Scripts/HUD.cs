using Godot;

public partial class HUD : CanvasLayer
{

	[Signal]
	public delegate void StartGameEventHandler();

	[Signal]
	public delegate void UnPauseGameEventHandler();

	public override void _Ready()
	{
		GetNode<Control>("PauseControl").Hide();
	}

	public void ShowMessage(string text)
	{
		var message = GetNode<Label>("MessageLabel");
		message.Text = text;
		message.Show();

		GetNode<Timer>("MessageTimer").Start();
	}

	public async void ShowGameOver()
	{
		ShowMessage("Hävisit pelin");

		var messageTimer = GetNode<Timer>("MessageTimer");
		await ToSignal(messageTimer, Timer.SignalName.Timeout);

		await ToSignal(GetTree().CreateTimer(0.5), SceneTreeTimer.SignalName.Timeout);
		GetNode<Button>("StartButton").Show();
	}

	public void UpdateScore(int score)
	{
		GetNode<Label>("ScoreLabel").Text = $"Pisteet : {score.ToString()}";
	}

	public void ShowPauseMenu()
	{
		GetNode<Control>("PauseControl").Show();
	}
	
	private void OnStartButtonPressed()
	{
		GetNode<Button>("StartButton").Hide();
		EmitSignal(SignalName.StartGame);
	}

	private void OnUnPauseButtonPressed()
	{
		GetNode<Control>("PauseControl").Hide();
		EmitSignal(SignalName.UnPauseGame);
	}

	private void OnMessageTimerTimeout()
	{
		GetNode<Label>("MessageLabel").Hide();
	}

}
