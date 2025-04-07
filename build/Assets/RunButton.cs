using Godot;
using System;
using System.Collections.Generic;

public partial class RunButton : Node3D
{
    // A private Node3D variable for our StartButton
    private ButtonSpawn startButton = new ButtonSpawn();

    public override void _Ready()
    {
        // Get our boxes from StartButton
        startButton = GetNode<ButtonSpawn>("../StartButton");
    }

    public override void _Process(double delta)
    {
        //// See if button B is pressed
        //if (Input.IsKeyPressed(Key.B))
        //{

        //    GD.Print("B pressed!!!");
        //    if (startButton.boxes.GetChildCount() == 0)
        //    {
        //        GD.Print("Boxes is empty!!! Please start the Conveyor belt!!!");
        //    }
        //    else
        //    {
        //        for (int i = 0; i < startButton.boxes.GetChildCount(); i++)
        //        {
        //            startButton.GetChild(i);
        //        }
            //}
        //}
    }
}
