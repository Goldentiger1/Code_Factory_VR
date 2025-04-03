using Godot;
using System;


public partial class ButtonSpawn : Node3D
{
    // A variable for our button
    public Node3D buttonNode = new Node3D();
    // A private vector3 variable to see is any box in this position
    private Vector3 boxPos = new Vector3(3.0f, 1.45f, -4.0f);
    // A private Area3D variable to see is our box on a conveyor belt
    private Area3D boxTrigger = new Area3D();
    // A private Node3d parent to contain boxes
    private Node3D Boxes = new Node3D();
    // A private PackeScene for the child box loading
    private PackedScene boxScene = new PackedScene();
    // A private Node3D for box child
    private Node3D box = new Node3D();


    public override void _Ready()
    {
        // Get our button from scene.
        buttonNode = this.GetNodeOrNull<Node3D>(".");
        // Get our trigger from scene
        boxTrigger = GetNode<Area3D>("../../BoxTrigger/Area3D");
        boxScene = GD.Load<PackedScene>("res://Assets/Box.tscn");
        AddChild(Boxes);
    }

    public override void _Process(double delta)
    {
        // Debug button preess for now.
        if(Input.IsKeyPressed(Key.A))
        {
            GD.Print("Key pressed");
            if(Boxes.GetChildCount() == 0)
            {
                GD.Print("Creating box");
                box = boxScene.Instantiate<Node3D>();
                box.Position = boxPos;
                Boxes.AddChild(box);
            }
        }
    }
}
