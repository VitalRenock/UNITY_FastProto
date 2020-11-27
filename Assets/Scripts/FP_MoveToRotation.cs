using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FP_MoveToRotation : FP_Main
{
    [Header ("Forward Vector")]
    public bool _forwardTarget;
    public FP_Space _forwardSpace;
    public Transform _spaceForwardRef;
    public Vector3 _forwardVector;

    [Header("Upward Vector")]
    [Space(10)]
    public bool _upwardTarget;
    public FP_Space _upwardSpace;
    public Transform _spaceUpwardRef;
    public Vector3 _upwardVector;


	private void Update()
	{
		// Define Vector Z
		Vector3 zVector = DefineDirectionVector(_forwardVector, _forwardSpace, _spaceForwardRef, _forwardTarget);

		// Define Vector Y
		Vector3 yVector = DefineDirectionVector(_upwardVector, _upwardSpace, _spaceUpwardRef, _upwardTarget);

		// Aplly rotation
		transform.rotation = Quaternion.LookRotation(zVector, yVector);
	}
}
