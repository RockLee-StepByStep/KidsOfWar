using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] GameObject Player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Vector3 LookAtThePlayer = Player.transform.position - transform.position;
        Vector3 NormVector = Vector3.Normalize(LookAtThePlayer);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, NormVector * 2);


        //Vector3.Cross
    }
}
