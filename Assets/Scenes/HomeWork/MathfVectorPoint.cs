using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfVectorPoint : MonoBehaviour
{
    public Transform objectOne;
    public Transform ObjectTwo;
    float pointOne;

    void Update()
    {
        ShowMeResult();
    }

    void OnDrawGizmosSelected()
    {
        if (pointOne < 200f)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(objectOne.position, ObjectTwo.position);
            //Debug.Log("ATTACK!!!");
        }
    }
    private void ShowMeResult()
    {
     
         pointOne=Vector3.Magnitude(ObjectTwo.position)-Vector3.Magnitude(objectOne.position);
        //var pointTwo = Vector3.Magnitude(ObjectTwo.position);
        if (pointOne < 200f)
        {
            // Draws a blue line from this transform to the target
            //Gizmos.color = Color.blue;
            //Gizmos.DrawLine(objectOne.position, ObjectTwo.position);
            Debug.Log("ATTACK!!!");
        }
        print(pointOne);
       
    }


}
