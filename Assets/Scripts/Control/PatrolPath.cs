using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace RPG.Control
{
public class PatrolPath : MonoBehaviour
{
        [SerializeField] float radiusWayPoint;
        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {

                // GetComponentInChildren<Gizmos>();
                Gizmos.DrawSphere(transform.GetChild(i).position, radiusWayPoint);
                Gizmos.color = Color.blue;

                int j = i + 1;
                if (j == transform.childCount)
                {
                     j = 0;
                }
                Gizmos.DrawLine(GetWayPatrolPosition(i), GetSecondWay(j));
            }
        }

        private Vector3 GetSecondWay(int j)
        {
            return transform.GetChild(j).position;
        }

        private Vector3 GetWayPatrolPosition(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}

