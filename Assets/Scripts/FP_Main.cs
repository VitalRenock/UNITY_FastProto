using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FP_Space
{
	World,
	Local
}

public class FP_Main : MonoBehaviour
{
	protected Vector3 DefineDirectionVector(Vector3 vector, FP_Space space, Transform spaceRef, bool isTarget)
	{
		Vector3 definedVector = Vector3.zero;
		Vector3 _target;

		if(isTarget)
		{
			if (spaceRef != null)
			{
				if(space == FP_Space.Local) { _target = spaceRef.TransformPoint(vector); }
				else { _target = spaceRef.position + vector; }
			}
			else
			{
				if (space == FP_Space.Local) { _target = transform.TransformPoint(vector); }
				else { _target = vector; }
			}
			definedVector = _target - transform.position;
		}
		else
		{
			if (space == FP_Space.Local)
			{
				if (spaceRef != null) { definedVector = spaceRef.TransformDirection(vector); }
				else { definedVector = transform.TransformDirection(vector); }
			}
			else
			{
				definedVector = vector;
			}
		}

		return definedVector;
	}

	protected Vector3 DefinePositionVector(Vector3 vector, FP_Space space, Transform spaceRef)
	{
		Vector3 definedVector = Vector3.zero;

		if (space == FP_Space.Local)
		{
			if (spaceRef != null) { definedVector = spaceRef.TransformPoint(vector); }
			else { definedVector = transform.TransformPoint(vector); }
		}
		else
		{
			if (spaceRef != null)
			{
				definedVector = spaceRef.position + vector;
			}
			else
			{
				definedVector = vector;
			}
		}

		return definedVector;
	}
}
