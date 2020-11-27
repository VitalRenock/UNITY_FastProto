using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(SpawnJenga))]
public class JengaEditor : Editor
{
	SpawnJenga _myScript;
	private void OnEnable()
	{
		_myScript = (SpawnJenga)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (GUILayout.Button("Create a jenga"))
		{
			_myScript.CreateJenga();
		}
		if (GUILayout.Button("Color Change"))
		{
			_myScript.ColorChanges();
		}

	}


}
