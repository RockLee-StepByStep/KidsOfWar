using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;
using System;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        
        private Health Targettransform;
        private Animator animatorChild;
        [SerializeField] private float TimeSinceLastAttack = 1;
        private float TimeLastAttack = 0;
        private bool _deadObj;
        [SerializeField] Vector3 fightLook;  
        [SerializeField] Transform handPointFor = null;
        [SerializeField] Weapon defultWeaponen= null;
        Weapon currentWeapon = null;

        private void Start()
        {
            //animatorChild = GameObject.FindGameObjectWithTag("banan").GetComponent<Animator>();
            animatorChild = GetComponent<Animator>();
            EquipWeapon(defultWeaponen);
        }

        private void Update()
        {
            TimeLastAttack += Time.deltaTime;
            

            if (Targettransform == null) return;
            if (Targettransform.isDead()) return;

            if (!RangeDistance())
            {
                GetComponent<MovePlayer>().MoveTo(Targettransform.transform.position);
            }
            else
            {
                GetComponent<MovePlayer>().Cancel();
                Hit();
            }

        }

        

        private bool RangeDistance()
        {
            return Vector3.Distance(transform.position, Targettransform.transform.position) < currentWeapon.GetFightDistance();
        }

        public bool CanAttack(GameObject CombatTarget)
        {
            if(CombatTarget == null) { return false; }
            Health targetToTest = CombatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.isDead();
        }
        public void Attack(GameObject CombatTarget)
        {

            GetComponent<ActionScheduler>().StartAction(this);
            Targettransform = CombatTarget.GetComponent<Health>();
            transform.LookAt(Targettransform.transform);
            print("Попался дружок-пирожог");
        }
        public void Cancel()
        {
            Debug.Log(101);
            Targettransform = null;
            GetComponent<Animator>().SetTrigger("StopAttack");
        }

        private void Hit()
        {
            if (TimeLastAttack > TimeSinceLastAttack)
            {
                
                animatorChild.SetTrigger("Attack");
                TimeLastAttack = 0;
            }

        }
        void HitEvent()
        {

            if (Targettransform!=null && _deadObj==false)
            {
                Health health = Targettransform.GetComponent<Health>();
                health.TakeDamage(currentWeapon.GetDamage());
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (currentWeapon == null) return;
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(handPointFor, animator);
        }
    }
}
