using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RobotArm))]
public class RobotArmEditor : Editor {

	public override void OnInspectorGUI() {
		var robot = (RobotArm)target;
		DrawDefaultInspector();
		
		if(GUILayout.Button("Calculate arm length"))
		{
			robot.CalculateArmLength();
		}
	}
}
