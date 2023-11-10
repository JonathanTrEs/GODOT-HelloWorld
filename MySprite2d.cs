using Godot;
using System;

public partial class MySprite2d : Sprite2D {
	private int speed = 400;
	private float angularSpeed = Mathf.Pi;
	
	public override void _Process(double delta) {
		Rotation += angularSpeed * (float)delta;
		var velocity = Vector2.Up.Rotated(Rotation) * speed;
		Position += velocity * (float)delta;
	}
}
