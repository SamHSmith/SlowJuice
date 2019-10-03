using Godot;
using System;

public class Human : RigidBody2D
{
    private float _speed=120;
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        //This should all be moved to a seperate input class later.
        float move=0;
        if(Input.IsKeyPressed((int)KeyList.Right))
            move++;
        if(Input.IsKeyPressed((int)KeyList.Left))
            move--;

        Move(move);
    }

    public void Move(float x){
        this.SetLinearVelocity(Vector2.Right*x*_speed);
    }
}
