using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.HomeWork.Scripts
{
    public class MathfVectorPoint : MonoBehaviour
    {
        public Transform objectOne;
        public Transform ObjectTwo;
        float pointOne;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ShowMeResult();
            //OnDrawGizmosSelected();
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

            pointOne = Vector3.Magnitude(ObjectTwo.position) - Vector3.Magnitude(objectOne.position);
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
}