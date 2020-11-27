using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class FP_TorqueToRotation : FP_Physic
{
	[Header("Forward Vector")]
	public bool _forwardTarget;
	public FP_Space _forwardSpace;
	public Transform _spaceForwardRef;
	public FP_InputVector3 _forwardVector;

	[Header("Upward Vector")]
	[Space(10)]
	public bool _upwardTarget;
	public FP_Space _upwardSpace;
	public Transform _spaceUpwardRef;
	public FP_InputVector3 _upwardVector;

	[Header("Rigidbody")]
	[Space(10)]
	public FP_InputFloat _torque;

	Vector3 _xVector;
	Vector3 _yVector;
	Vector3 _zVector;

	Vector3 _crossX;
	Vector3 _crossY;
	Vector3 _crossZ;
	Vector3 _perpendicularY;

	[Range(-1,1)]
	public float _alignThreshold=1;

	public UnityEvent OnAlign;
	public UnityEvent OnNotAlign;
	public UnityEvent OnEnterAlign;
	public UnityEvent OnExitAlign;

	bool _isAlign;

	[Range(0,10)]
	public float _axesDisplaySize = 1;

	void Update()
	{
		DefineRotationAxes();

		// Call Events
		if(Vector3.Dot(transform.forward,_zVector.normalized)> _alignThreshold)
		{
			if (!_isAlign)
			{
				OnEnterAlign.Invoke();
				_isAlign = true;
			}
			OnAlign.Invoke();
		}
		else
		{
			if(_isAlign)
			{
				OnExitAlign.Invoke();
				_isAlign = false;
			}
			OnNotAlign.Invoke();
		}
	}

	void DefineRotationAxes()
	{
		// Define _zVector
		_zVector = DefineDirectionVector(_forwardVector.DefineVector3(), _forwardSpace, _spaceForwardRef, _forwardTarget).normalized;

		// Define _yVector
		_yVector = DefineDirectionVector(_upwardVector.DefineVector3(), _upwardSpace, _spaceUpwardRef, _upwardTarget).normalized;

		// Define = _crossX _crossY and _crossZ 

		_crossZ = Vector3.Cross(transform.forward, _zVector);

		_xVector = Vector3.Cross(_yVector, _zVector);
		_crossX = Vector3.Cross(transform.right, _xVector);

		_perpendicularY = -Vector3.Cross(_xVector, _zVector);
		_crossY = Vector3.Cross(transform.up, _perpendicularY);

	}

	protected override void ApplyForce()
	{
		_rigidbody.AddTorque((_crossZ + _crossY) * _torque.DefineFloat() * Time.fixedDeltaTime);
	}

	private void OnDrawGizmosSelected()
	{
		DefineRotationAxes();

		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position, _zVector * _axesDisplaySize) ;

		Gizmos.color = Color.green;
		Gizmos.DrawRay(transform.position, _perpendicularY * _axesDisplaySize);

		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(transform.position, _yVector * _axesDisplaySize);

		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, _xVector * _axesDisplaySize);


		Handles.color = new Color(0, 0, 1, 0.1f);
		float zAngle = Vector3.SignedAngle(transform.forward, _zVector, _crossZ);
		Handles.DrawSolidArc(transform.position, _crossZ, transform.forward, zAngle, _axesDisplaySize*0.5f);

		Handles.color = new Color(1, 0, 0, 0.1f);
		float xAngle = Vector3.SignedAngle(transform.right, _xVector, _crossX);
		Handles.DrawSolidArc(transform.position, _crossX, transform.right, xAngle, _axesDisplaySize * 0.5f);

		Handles.color = new Color(0, 1, 0, 0.1f);
		float yAngle = Vector3.SignedAngle(transform.up ,_perpendicularY, _crossY);
		Handles.DrawSolidArc(transform.position, _crossY, transform.up, yAngle, _axesDisplaySize * 0.5f);
	}
}
