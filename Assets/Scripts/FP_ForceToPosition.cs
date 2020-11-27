using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class FP_ForceToPosition : FP_Physic
{
    public FP_InputVector3 _position;
    public FP_Space _space;
    public Transform _spaceRef;

    public FP_InputFloat _force;

    Vector3 _worldPosition;
    Vector3 _forceDirection;

	public UnityEvent OnIn;
	public UnityEvent OnOut;
	public UnityEvent OnEnter;
	public UnityEvent OnExit;

	public float _radius;

	bool _isIn;


	private void Update()
    {
		DefineWorldPosition();

        _forceDirection = (_worldPosition - transform.position).normalized;


		// Call Events
		if(_radius < Vector3.Distance(_worldPosition, _position.DefineVector3()))
		{
			if(!_isIn)
			{
				OnEnter.Invoke();
				_isIn = true;
			}
			OnIn.Invoke();
		}
		else
		{
			if (_isIn)
			{
				OnExit.Invoke();
				_isIn = false;
			}
			OnOut.Invoke();
		}
    }

	void DefineWorldPosition()
	{
		_worldPosition = DefinePositionVector(_position.DefineVector3(), _space, _spaceRef);
	}

	protected override void ApplyForce()
	{
		_rigidbody.AddForce(_forceDirection * _force.DefineFloat() * Time.fixedDeltaTime);
		//Debug.Log(_force.DefineFloat());
	}

	private void OnDrawGizmosSelected()
	{
		float color = Mathf.Clamp(Mathf.Cos(Time.time), 0f, 255f);
		Handles.color = new Color(color, color, color);


		DefineWorldPosition();
		if(_space == FP_Space.Local)
		{
			Handles.DrawLine(transform.position, _worldPosition);
			Gizmos.DrawIcon(_worldPosition, "Torche", true);
		}
		else
		{
			Handles.DrawDottedLine(transform.position, _worldPosition, 10f);
			Gizmos.DrawIcon(_worldPosition, "Torche", true);
		}

		//Gizmos.DrawLine(transform.position, DefinePositionVector(_position, _space, _spaceRef));
		//Gizmos.color = _space == FP_Space.Local ? Color.blue : Color.red;
		//Handles.Label((transform.position + _worldPosition) * 0.5f, (_worldPosition - transform.position).magnitude.ToString());    ===> IMPORTER using UnityEditor;
	}
}
