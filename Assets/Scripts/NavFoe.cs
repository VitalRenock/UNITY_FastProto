using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavFoe : MonoBehaviour
{
	private NavMeshAgent _myNavFoe;
	public Transform _target;

	private void Start()
	{
		_myNavFoe = GetComponent<NavMeshAgent>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		_myNavFoe.destination = _target.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Begin On TRIGGER");

		if (other.tag == "Player")
		{
			SceneManager.LoadScene("GameOver");
			Debug.Log("On TRIGGER");
		}
	}
}
