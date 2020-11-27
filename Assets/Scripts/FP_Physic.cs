using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FP_Physic : FP_Main
{
	public bool _isApllyingForce = false;
	protected Rigidbody _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		StartCoroutine(ApplyingContinuousForce());
	}


	IEnumerator ApplyingContinuousForce()
	{
		while (true)
		{
			while (_isApllyingForce)
			{
				ApplyForce();
				yield return new WaitForFixedUpdate();
			}
			yield return null;
		}
	}
	public void IsApplyingForce(bool enable)
	{
		_isApllyingForce = enable;
	}

	protected virtual void ApplyForce()
	{
		// Override this in any child class
	}
}
