using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace WaypointsTool
{
    public class WaypointsToolMenu
    {
        //menu item for the waypoint tool
        [MenuItem("WaypointsTool/Create/Waypoints")]
        static void CreateWaypoints(){
            GameObject wpo = new GameObject();
            wpo.AddComponent<WaypointsScript>();
            wpo.name = "Waypoints";


            Selection.activeObject = wpo;
            Undo.RegisterCreatedObjectUndo(wpo, "Created " + wpo.name);
        }
       
    }
}