using Godot;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public int jumpCount = 0;

	public void Start(Vector2 position)
	{
		Position = position;
		Show();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (jumpCount > 0)
		{
			velocity.Y += gravity * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("flap"))
		{
			velocity.Y = JumpVelocity;
			jumpCount += 1;
		}


		Velocity = velocity;
		MoveAndSlide();
	}

	public void Die()
	{
		QueueFree();
	}
}
