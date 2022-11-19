using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] private float speedRotate = 200;
    // Update is called once per frame
    void Update()
    {
        RotateAroundTarget();
    }

    private void RotateAroundTarget()
    {
        transform.RotateAround(target.transform.position,transform.up,speedRotate * Time.deltaTime );
       // transform.Rotate()
    }
}
