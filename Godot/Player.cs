using Godot;

public class Player : KinematicBody2D {
    [Export] private int _walkSpeed = 200;

    private Vector2 _velocity;
    private Vector2 _direction;
    
    private AnimatedSprite _animatedSprite;

    public override void _Ready() {
        _animatedSprite = GetNode<AnimatedSprite>("Sprite");
    }

    private static Vector2 GetInputDirection() {
        var direction = new Vector2();
        if (Input.IsActionPressed("ui_right"))
            direction.x += 1; 

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

        // Idle 
        if (Vector2.Zero == _direction)
            _animatedSprite.Play("Idle");

        // Walk movement
        else {
            _velocity = _direction * _walkSpeed;
            LookAt(Position + _direction);
            MoveAndSlide(_velocity);
            _animatedSprite.Play("Walk");
        }
    }
}