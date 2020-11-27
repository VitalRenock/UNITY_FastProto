using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJenga : MonoBehaviour
{
    public GameObject _prefabJenga;
    public int _towerHight;
    public int _towerwidth;

    public List<Rigidbody> _jengaTower = new List<Rigidbody>();
    public List<Material> _jengaMaterials = new List<Material>();

	public void CreateJenga()
	{
		Time.timeScale = 0.5f;

		for (float j = 0; j < _towerHight; j += 0.5f)
		{
			for (int i = -1; i < _towerwidth - 1; i++)
			{
				_jengaTower.Add(Instantiate(_prefabJenga, new Vector3(0f, j, i), Quaternion.identity, transform).GetComponent<Rigidbody>());
			}
			transform.Rotate(Vector3.up, 90f);
		}

		for (int i = 0; i < _jengaTower.Count; i++)
		{
			_jengaTower[i].transform.parent = null;
		}
	}

	public void ColorChanges()
	{
		//foreach ()
		//{
		//	item.GetComponent<Renderer>().material.color = new Color(Mathf.Abs(item.position.x / 100), Mathf.Abs(item.position.y / 100), Mathf.Abs(item.position.z / 100));
		//}
	}
}
