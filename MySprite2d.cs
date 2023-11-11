using Godot;
using System;

public partial class MySprite2d : Sprite2D {
	private int speed = 400;
	private float angularSpeed = Mathf.Pi;
	
	public override void _Process(double delta) {
		//moveWithInput();
		moveAutomatically(delta);
	}
	
	private void OnButtonPressed() {
		SetProcess(!IsProcessing());
	}
	
	public override void _Ready() {
		var timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout;
	}
	
	private void OnTimerTimeout() {
		Visible = !Visible;
	}
	
	private void moveAutomatically(double delta){
		Rotation += angularSpeed * (float)delta;
		var velocity = Vector2.Up.Rotated(Rotation) * speed;
		Position += velocity * (float)delta;
	}
	
	private void moveWithInput(double delta){
		// Read input left and right
		var direction = 0;
		if (Input.IsActionPressed("ui_left")) {
			direction = -1;
		} 
		if (Input.IsActionPressed("ui_right")) {
			direction = 1;
		}
		Rotation += angularSpeed * direction * (float)delta;
		// Move up
		var velocity = Vector2.Zero;
		if (Input.IsActionPressed("ui_up")) {
			velocity = Vector2.Up.Rotated(Rotation) * speed;
		}
		Position += velocity * (float)delta;
	}
}
