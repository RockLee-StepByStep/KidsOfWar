using System.Collections;
using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float health;
       

       
        private bool HasDead = false;
        public bool isDead()
        {
            return HasDead;
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            if (health == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (HasDead) return;
            HasDead = true;
            GetComponent<Animator>().SetTrigger("Dying");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }


    }
}