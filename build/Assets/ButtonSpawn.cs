using Godot;
using System;
using System.Threading;
using System.Collections.Generic;


public partial class ButtonSpawn : Node3D
{
    // A public Node3D that contains our boxes
    public Node3D nodeBoxes = new Node3D();
    // A public list for boxes from Node3 boxes container
    public List<Node3D>[] listBoxes = new List<Node3D>[5];
    // A private PackedScene of our box
    private PackedScene boxScene = new PackedScene();
    // A public Node3D of our box
    public Node3D box = new Node3D();
    // A private vector3 for our box spawn position
    private Vector3 boxPos = new Vector3(3.0f, 1.45f, -4.0f);
    //// A private Area3D variable to see is our box on a conveyor belt
    //private Area3D boxTrigger = new Area3D();
    // A private boolean value to see is button pressed
    private bool buttonPressed = false;

    public override void _Ready()
    {
        // Set a name for our box container
        nodeBoxes.Name = "Boxes";
        // Set our box containers position in the scene.
        nodeBoxes.Position = new Vector3(0.0f, 0.0f, 0.0f);
        // Wait for main Node3D to be free with CallDeferred()
        // and then add our Node3D boxes to the scene
        GetNode<Node3D>("../..").CallDeferred("add_child", nodeBoxes);
        // Preload our box PackedScene
        boxScene = GD.Load<PackedScene>("res://Assets/Box.tscn");
    }

    public override void _Process(double delta)
    {
        switch(buttonPressed)
        {
            case false when Input.IsKeyPressed(Key.A):
                buttonPressed = true;
                GD.Print(buttonPressed);
                Thread.Sleep(1000);
                break;
            case true when Input.IsKeyPressed(Key.A):
                buttonPressed = false;
                GD.Print(buttonPressed);
                Thread.Sleep(1000);
                break;
        }

        do
        {
            
        } while (buttonPressed == true);
    }
}
