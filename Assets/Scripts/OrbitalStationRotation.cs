using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalStationRotation : MonoBehaviour
{
	public float _speedRotation;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0f, _speedRotation * Time.deltaTime, 0f);
    }
}
