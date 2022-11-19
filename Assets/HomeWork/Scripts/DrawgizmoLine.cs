using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawgizmoLine : MonoBehaviour
{
    [SerializeField] private GameObject Target;

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
       // Gizmos.DrawLine(transform.position, Target.transform.position);
    }
}
