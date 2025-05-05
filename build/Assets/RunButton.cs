using Godot;
using System;

public partial class RunButton : Node3D
{
	// A public MeshInstance3D of RunButton to switch it's
	// color on button press
	public MeshInstance3D rMeshInstace3D = new MeshInstance3D();
	// A public StandardMaterial3D of RunButton to switch it's
	// color on button press
	public StandardMaterial3D rStandardMaterial3D = new StandardMaterial3D();
	// A public boolean variable to see is button pressed
	public bool rButtonPressed = false;
	// A private StartButton variable
	private ButtonSpawn startButton = null;
	// A private Vector3 position variable to see in which
	// position next box in the list is in the scene.
	private Vector3 nBoxPos = new Vector3(0.0f, 0.0f, 0.0f);
	// A private Vector3 position variable to
	// see is box spawn position free
	private Vector3 bSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);
    // A private list of boxes positions that we will go
    // through to see that they are not in spawn point
	private Vector3[] lBoxPos = new Vector3[5];
	// A private float variable to time boxes movement
	private float time = 0.0f;

	public override void _Ready()
	{
		// Get our boxes from StartButton
		startButton = GetNode<ButtonSpawn>("../StartButton");
        // Get buttons meshInstace
        rMeshInstace3D = GetNode<MeshInstance3D>("ButtonBody3D/MeshInstance3D");
    }

	public override void _Process(double delta)
	{
        // Switch case to see is our RunButton pressed on or off
		switch(rButtonPressed)
		{
            // When the RunButton is off and it is pressed switch to on
            case false when Input.IsActionJustPressed("Key_B"):
				// If StartButton is off then keep RunButton off and
				// ask to turn StartButton on first. Otherwise continue normally
				if(startButton.sButtonPressed == false)
				{
					GD.Print("Please press the start button first");
					break;
				}
				else
				{
                    // Turn RunButton to purple
					rStandardMaterial3D.AlbedoColor = new Color(0.5f, 0.0f, 5.0f);
					rMeshInstace3D.SetSurfaceOverrideMaterial(0, rStandardMaterial3D);
                    // Switch rButtonPressed from false to true
					rButtonPressed = true;
                    break;
                }
            // When the RunButton is on and it is pressed switch to off
            case true when Input.IsActionJustPressed("Key_B"):
                // Turn RunButton red
                rStandardMaterial3D.AlbedoColor = new Color(1.0f, 0.0f, 0.0f);
                rMeshInstace3D.SetSurfaceOverrideMaterial(0, rStandardMaterial3D);
                // Switch rButtonPressed from true to false
                rButtonPressed = false;
                break;
		}
		// If RunButton is turned on spawn the boxes into the scene
		if(rButtonPressed == true)
		{
			time += (float)delta;
			GD.Print(time);
			for(int i = 0; i < startButton.lNode3DBoxes.Length; i++)
			{
				if(nBoxPos.X <= (startButton.pdSpawnPos.X - 3.0f))
				{
                    startButton.node3DBoxes.AddChild(startButton.lNode3DBoxes[i]);
                    lBoxPos[i] = startButton.lNode3DBoxes[i].Position;
                    nBoxPos = startButton.lNode3DBoxes[i].Position;
                    continue;
                } else if(nBoxPos.X <=startButton.pdSpawnPos.X)
				{
                    for (int j = 0; j < lBoxPos.Length; j++)
                    {
                        if (lBoxPos[j] == bSpawnPos)
                        {
                            continue;
                        }
						else
						{
                            lBoxPos[j] -= new Vector3(0.1f, 0.0f, 0.0f);
                            startButton.lNode3DBoxes[j].Position = lBoxPos[j];
                            nBoxPos = startButton.lNode3DBoxes[j].Position;
                        }
							
                    }
                }
			}
		}
	}
}
