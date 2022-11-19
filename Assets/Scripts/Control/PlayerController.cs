using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Control
{
public class PlayerController : MonoBehaviour
{

        private Health health;

        private void Start()
        {
            health = GetComponent<Health>();
        }
        private void Update()
        {
            if(health.isDead()) return;
            if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;
            print("Nothing to do");
        }


        private bool InteractWithCombat()
        {
           RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
               CmbatTarget Target = hit.transform.GetComponent<CmbatTarget>();
                
                if (Target == null) continue;


                if (!GetComponent<Fighter>().CanAttack(Target.gameObject))
                {
                    continue;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(Target.gameObject);
                }
                return true;
            }
            return false;
        }
        private bool InteractWithMovement()
        {

            RaycastHit hit;
            bool HasDiactivate = Physics.Raycast(GetMouseRay(), out hit);
            if (HasDiactivate)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<MovePlayer>().StartMove(hit.point);
                  //  GetComponent<Fighter>().Cancel();
                }
                return true;

            }
            return false;
        }

       

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

    }
}

