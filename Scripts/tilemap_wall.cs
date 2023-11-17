using Godot;
using System;

public partial class tilemap_wall : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override void _PhysicsProcess(double delta)
    {
        Position += new Vector2(-2, 0);
    }
}
