using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_MoveToPosition : MonoBehaviour
{
    public Vector3 _position;

    public FP_Space _space;

    public Transform _spaceRef;

    private void Update()
    {
        if(_space == FP_Space.World) { transform.position = _position; }
        //Sinon si on choisit de se déplacer dans l'espace local et que l'objet de référence pour se déplacer dans son espace n'est pas null
        else if(_space == FP_Space.Local && _spaceRef != null)
        {
            // Convertir la position d'un espace global vers un espace local d'un autre objet.
            transform.position = _spaceRef.TransformPoint(_position);
        }
    }
}
