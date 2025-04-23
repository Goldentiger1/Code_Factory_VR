using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

public partial class RunButton : Node3D
{
	// A private Node3D variable for our StartButton
	private ButtonSpawn startButton = new ButtonSpawn();
	// A private boolean value to see is button pressed
	private bool RButtonPressed = false;
	// A private Vector3 value to see is box spawn position free
	private Vector3 SBoxPos = new Vector3(0.0f, 0.0f, 0.0f);
	// A private compare value
	private Vector3 ComBoxPos = new Vector3(0.0f, 0.0f, 0.0f);
	// A private Vector3 list for box positions to go through
	private Vector3[] LBoxPos = new Vector3[5];
	// A private float time to make code wait a little before
	// going forward
	float time = 0.1f;

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
				for(int i = 0; i < startButton.listBoxes.Length; i++)
				{
					if (SBoxPos.X <= (startButton.boxPos.X - 3.0f))
					{
						startButton.nodeBoxes.AddChild(startButton.listBoxes[i]);
						LBoxPos[i] = startButton.listBoxes[i].Position;
						SBoxPos = startButton.listBoxes[i].Position;
						GD.Print("Loop number: " + i + "\n" + "Current box name: " + startButton.listBoxes[i].Name);
						continue;
					}
					else if(SBoxPos.X <= startButton.boxPos.X)
					{
						for(int j = 0; j < LBoxPos.Length; j++)
						{
							if (LBoxPos[j] == ComBoxPos)
							{
								continue;
							}
							else
							{
								LBoxPos[j] -=  new Vector3(0.1f, 0.0f, 0.0f);
								startButton.listBoxes[j].Position = LBoxPos[j];
								SBoxPos = startButton.listBoxes[i].Position;
								GD.Print("Loop number: " + i + "\n" + "List positions number: " + j + "\n" + "Position: " + LBoxPos[j]);
								GD.Print(time);
								if (time < 50000.0f)
								{
									time += time * (float)delta;
								}
								else if(time == 50000.0f)
								{
									GD.Print(time);
									time = 0.1f;
									continue;
								}
									
							}
						}
					}

				}
			}
		}
	}
}
