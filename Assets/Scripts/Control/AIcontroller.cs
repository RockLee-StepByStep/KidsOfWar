using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Control
{ 
public class AIcontroller : MonoBehaviour
{
        private float distanceArgry = 9;
        private float distanceChase = 19;
        private Health health;
        private GameObject player;
        private Fighter fighterBotState;
        private MovePlayer movePlayer;
        private Vector3 basePoint;
        [SerializeField] float TimeSinceWasSawPlayer = Mathf.Infinity;
        [SerializeField] float SuspicionTime = 4;



        private void Start()
        {
         movePlayer = GetComponent<MovePlayer>();
         basePoint = transform.position;
         health = GetComponent<Health>();
         player = GameObject.FindGameObjectWithTag("Player");
         fighterBotState = GetComponent<Fighter>();
        }
        void Update()
        {
            if (health.isDead()) return;
            _chasePoint();
            TimeSinceWasSawPlayer += Time.deltaTime;
        }


   private void _chasePoint()
        {
            
            if (DistanceAgry())
            {
                var pointDistance = Vector3.Distance(transform.position, player.transform.position);
                print(gameObject.name + pointDistance + " : catcha!");
                TimeSinceWasSawPlayer = 0;
                fighterBotState.Attack(player);
            }
            else if (DistanceChase())
            {
                GoBackHome();
            }
            else 
            {
                if (TimeSinceWasSawPlayer < SuspicionTime)
                {
                    GetComponent<ActionScheduler>().CancelCurrentAction();
                }
            }
           
            
        }


        private void GoBackHome()
        {
           movePlayer.StartMove(basePoint);
        }

        private bool DistanceAgry()
        {
            return Vector3.Distance(transform.position, player.transform.position) < distanceArgry;
        }
        private bool DistanceChase()
        {
            return Vector3.Distance(transform.position, player.transform.position) > distanceChase;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, distanceArgry);
        }

        


    }
}

