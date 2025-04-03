using Godot;
using System;

public partial class Main : Node3D
{
    private XRInterface _xRInterface;

    public override void _Ready()
    {
        _xRInterface = XRServer.FindInterface("OpenXR");
        if (_xRInterface != null && _xRInterface.IsInitialized())
        {
            GD.Print("OpenXR initialized successfully");

            // Turn off v-sync!
            DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Disabled);

            // Change our main viewport to output to the HMD
            GetViewport().UseXR = true;
        }
        else
        {
            GD.Print("OpenXR not onitialized, please check if your headset is connected");
        }
    }
}
