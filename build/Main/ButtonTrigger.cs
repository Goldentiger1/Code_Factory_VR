using Godot;
using System;

public partial class ButtonTrigger : Area3D
{
    // A private list of hands
    private Node3D[] hands = new Node3D[2];

    public override void _Ready()
    {
        // Place LefHand into hands[0]
        hands[0] = GetNode<Node3D>("../XROrigin3D/LeftHand/LeftHandNode3D");
        // Place RightHand into hands[1]
        hands[1] = GetNode<Node3D>("../XROrigin3D/RightHand/RightHandNode3D");
        // BodyEntered trigger
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node3D body)
    {
        foreach (Node3D hand in hands)
        {
            if (body == hand)
            {
                GD.Print("Entered");
            }
        }
    }
}
