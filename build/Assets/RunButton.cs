using Godot;
using System;
using System.Collections.Generic;

public partial class RunButton : Node3D
{
    // A private Node3D variable for our StartButton
    private ButtonSpawn startButton = new ButtonSpawn();
    // A private boolean value to see is button pressed
    private bool RButtonPressed = false;
    // A private Vector3 value to see is box spawn position free
    private Vector3 SBoxPos = new Vector3(0.0f, 0.0f, 0.0f);

    public override void _Ready()
    {
        // Get our boxes from StartButton
        startButton = GetNode<ButtonSpawn>("../StartButton");
    }

    public override void _Process(double delta)
    {
        // See if button B is pressed
        switch(RButtonPressed)
        {
            case false when Input.IsActionJustPressed("Key_B"):
                RButtonPressed = true;
                GD.Print(RButtonPressed);
                break;
            case true when Input.IsActionJustPressed("Key_B"):
                RButtonPressed = false;
                GD.Print(RButtonPressed);
                break;
        }

        if(RButtonPressed == true)
        {
            if (startButton.listBoxes[0] == null)
            {
                GD.Print("Start level first");
                RButtonPressed = false;
            }
            else
            {
                for(int i = 0; i < startButton.listBoxes.Length;)
                {
                    if(SBoxPos.X <= (startButton.boxPos.X - 3.0f))
                    {
                        SBoxPos = startButton.listBoxes[i].Position;
                        startButton.nodeBoxes.AddChild(startButton.listBoxes[i]);
                        i++;
                    }
                    else
                    {
                        startButton.listBoxes[i].Position.X = (startButton.listBoxes[i].Position.X - 0.5f * delta);
                    }
                }
            }
        }
    }
}
