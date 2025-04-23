using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

public partial class ButtonSpawn : Node3D
{
	// A public Node3D that contains our boxes
	public Node3D nodeBoxes = new Node3D();
	// A public list for boxes from Node3 boxes container
	public Node3D[] listBoxes = new Node3D[5];
	// A private PackedScene of our box
	private PackedScene boxScene = new PackedScene();
	// A public Node3D of our box
	public Node3D box = new Node3D();
	// A private Area3D for our buttonTrigger
	private Area3D sBoxTrigger = new Area3D(); 
	// A private vector3 for our box spawn position
	public Vector3 boxPos = new Vector3(3.0f, 1.45f, -4.0f);
	// A private boolean value to see is button pressed
	private bool sButtonPressed = false;
	// A private variable for list length
	private int lBoxeslength = 0;

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
		// Set the value into lBoxeslength of our listBoxes
		lBoxeslength = listBoxes.Length;
		// Set our StartButtons value into sBoxTrigger
		sBoxTrigger = GetNode<Area3D>("ButtonTrigger3D");
		// Get Area entered
		sBoxTrigger.BodyEntered += OnButtonTriggerEntered;
	}

	public override void _Process(double delta)
	{

		switch(sButtonPressed)
		{
			case false when Input.IsActionJustPressed("Key_A"):
				sButtonPressed = true;
				GD.Print(sButtonPressed);                
				break;
			case true when Input.IsActionJustPressed("Key_A"):
				sButtonPressed = false;
				GD.Print(sButtonPressed);
				break;
		}
		if(sButtonPressed == true)
		{
			if (listBoxes[0] == null)
			{
				for(int i = 0; i <= lBoxeslength; i++)
				{
					listBoxes[i] = new Node3D();
					box = boxScene.Instantiate<Node3D>();
					box.Name = "Box_" + (i + 1);
					box.Position = boxPos;
					listBoxes[i] = box;
				}
			}
		}

	}

	private void OnButtonTriggerEntered(Node3D hand)
	{
		GD.Print(hand);
		GD.Print("Entered");
    }


}

