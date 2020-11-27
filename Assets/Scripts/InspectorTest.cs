using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorTest : MonoBehaviour
{
	public bool _hide;
	public string _newName;
	public bool _me;
	public bool _orMe;

	public void CreateChild()
	{
		GameObject child = new GameObject(_newName);
		child.transform.SetParent(transform);
		child.transform.localPosition = Vector3.zero;
	}
}
