using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWork.Manareg
{
public class PlayerManager : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 40;
    
    public void MoveControl(GameObject PLobject)
        {
            PLobject.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);

            PLobject.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal"));
        } 
    
    
}
}

