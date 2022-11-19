using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Make new weapon", order = 1)]
public class Weapon : ScriptableObject
{
    [SerializeField] AnimatorOverrideController animatorOverride = null;
    [SerializeField] GameObject weaponen = null;
    [SerializeField] private float fightDistance;
    [SerializeField] private int Damage;

    public void Spawn(Transform handPoint,Animator animator)
    {
        if(weaponen != null)
        {
            Instantiate(weaponen, handPoint);
        }
        if(animatorOverride != null)
        {
             animator.runtimeAnimatorController = animatorOverride;
        }
        
    }

    public int GetDamage() { return Damage; }
    public float GetFightDistance() { return fightDistance; } 
}