using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(InspectorTest))]
public class InspectorTestEditor : Editor
{
	InspectorTest _myScript;
	private void OnEnable()
	{
		_myScript = (InspectorTest)target;
	}

	public override void OnInspectorGUI()
	{
		//base.OnInspectorGUI();
		_myScript._hide = EditorGUILayout.Toggle("Hide", _myScript._hide);
		if(_myScript._hide == true)
		{
			_myScript._newName = EditorGUILayout.TextField("Name of the duck", _myScript._newName);
		}

		if (GUILayout.Button("Create a duck"))
		{
			_myScript.CreateChild();
		}
	}


}
