using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Core
{
public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform cameraPos;
    [SerializeField] Vector3 cameraVectorPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraPos.transform.position = target.transform.position + cameraVectorPos;
    }
}
}

