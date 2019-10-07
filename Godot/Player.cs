using Godot;

public class Player : KinematicBody2D {
    [Export] private int _walkSpeed = 200;

    private Vector2 _velocity;
    private Vector2 _direction;

    private static Vector2 GetInputDirection() {
        var direction = new Vector2();
        if (Input.IsActionPressed("ui_right"))
            direction.x += 1;//Changed it to += so that the net movement from pressing up and down is 0

        if (Input.IsActionPressed("ui_left"))
            direction.x += -1;

        if (Input.IsActionPressed("ui_down"))
            direction.y += 1;

        if (Input.IsActionPressed("ui_up"))
            direction.y += -1;

        return direction.Normalized();
    }

    public override void _PhysicsProcess(float delta) {
        _direction = GetInputDirection();
        
        // Walk movement
        _velocity = _direction * _walkSpeed;
        MoveAndSlide(_velocity);
    }
}