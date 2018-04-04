using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaypointsScript))]

public class WaypointsEditor : Editor {
    WaypointsScript script;

	private void OnEnable()
	{
        script = (WaypointsScript) target;
	}

    //to override what is shown on the inspector
	public override void OnInspectorGUI()
	{
        base.OnInspectorGUI();

        if (GUILayout.Button("Add waypoint")){ //creating a button to add waypoints
            script.CreateWaypoints();
        } 
	}
}
