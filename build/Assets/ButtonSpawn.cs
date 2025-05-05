using Godot;
using System;

public partial class ButtonSpawn : Node3D
{
	// A public Node3D in our scene to store the boxes cleanly
	public Node3D node3DBoxes = new Node3D();
	// A public Node3D list of our boxes which we iterate through
	// to get our boxes and their values
	public Node3D[] lNode3DBoxes = new Node3D[5];
	// A public single Node3D of our box
	public Node3D box = new Node3D();
	// A public Vector3 position of our pre defined boxes spawn position
	public Vector3 pdSpawnPos = new Vector3(3.0f, 1.45f, -4.0f);
    // A public boolean variable to see is button pressed
    public bool sButtonPressed = false;
	// A private RunButton variable
	private RunButton runButton = null;
    // A private MeshInstance3D of StartButton to switch it's
    // color on button press 
	private MeshInstance3D sMeshInstance3D = new MeshInstance3D();
    // A private StandardMaterial3D of StartButton to switch it's
    // color on button press
	private StandardMaterial3D sStandardMaterial3D = new StandardMaterial3D();
    // A private PackedScene of our box that
    // we will initialize
    private PackedScene boxScene = new PackedScene();
	// A private int variable of the length of Node3D list
	private int lBoxesLenght = 0;
	
	public override void _Ready()
	{	
		// Get our RunButton for it's public variables
		runButton = GetNode<RunButton>("../RunButton");
		// Preload our box PackedScene
		boxScene = GD.Load<PackedScene>("res://Assets/Box.tscn");
        // Get our StartButtons MeshInstace3D
        sMeshInstance3D = GetNode<MeshInstance3D>("ButtonBody3D/MeshInstance3D");
        // Give our scene Node3D container a name
        node3DBoxes.Name = "Boxes";
        // Give our scene Node3D container a position in the scene
        node3DBoxes.Position = new Vector3(0.0f, 0.0f, 0.0f);
        // Wait until Node3D main script is finished before
        // adding our Node3D container to the scene with CallDeferred()
        GetNode<Node3D>("../..").CallDeferred("add_child", node3DBoxes);
        // Set the value of our Node3D list lenght to the lBoxesLenght variable
        lBoxesLenght = lNode3DBoxes.Length;
    }

	public override void _Process(double delta)
	{
		// Switch case to see is our StartButton pressed on or off
		switch(sButtonPressed)
		{
			// When the StartButton is off and it is pressed switch to on
			case false when Input.IsActionJustPressed("Key_A"):
				// Turn StartButton to green
				sStandardMaterial3D.AlbedoColor = new Color(0.0f, 1.0f, 0.0f);
				sMeshInstance3D.SetSurfaceOverrideMaterial(0, sStandardMaterial3D);
				// Switch sButtonPressed from false to true
				sButtonPressed = true;
                break;
			// When the StartButton is on and it is pressed switch to off
			case true when Input.IsActionJustPressed("Key_A"):
				// If RunButton is also turned on then turn it off
				// otherwise just turn StartButton off
				if(runButton.rButtonPressed == true)
				{
					// Turn RunButton red
					runButton.rStandardMaterial3D.AlbedoColor = new Color(1.0f, 0.0f, 0.0f);
					runButton.rMeshInstace3D.SetSurfaceOverrideMaterial(0, runButton.rStandardMaterial3D);
					// Switch rButtonPressed from true to false
					runButton.rButtonPressed = false;
					// Turn StartButton red
					sStandardMaterial3D.AlbedoColor = new Color(1.0f, 0.0f, 0.0f);
					sMeshInstance3D.SetSurfaceOverrideMaterial(0, sStandardMaterial3D);
					// Switch sButtonPressed from true to false
					sButtonPressed = false;
					break;
                }else
				{
                    // Turn StartButton red
                    sStandardMaterial3D.AlbedoColor = new Color(1.0f, 0.0f, 0.0f);
                    sMeshInstance3D.SetSurfaceOverrideMaterial(0, sStandardMaterial3D);
                    // Switch sButtonPressed from true to false
                    sButtonPressed = false;
                    break;
                }
		}

		// If StartButton is turned on. Instansiate the scene
		// by loading the boxes into the Node3D list
		if(sButtonPressed == true && lNode3DBoxes[0] == null)
		{
			for(int i = 0; i < lNode3DBoxes.Length; i++)
			{
				lNode3DBoxes[i] = new Node3D();
				box = boxScene.Instantiate<Node3D>();
				box.Name = "Box_" + (i + 1);
				box.Position = pdSpawnPos;
				lNode3DBoxes [i] = box;
			}

			// If the StartButton is turned off empty the box list
		} else if(sButtonPressed == false && node3DBoxes.GetChildCount() == 0 && lNode3DBoxes[0] != null)
		{
			for(int i = 0; i < lNode3DBoxes.Length;i++)
			{
				lNode3DBoxes[i] = null;
			}
		}
    }
}

