using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class youWin : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Begin On TRIGGER");

		if (other.tag == "Player")
		{
			SceneManager.LoadScene("YouWin");
			Debug.Log("On TRIGGER");
		}
	}
}
