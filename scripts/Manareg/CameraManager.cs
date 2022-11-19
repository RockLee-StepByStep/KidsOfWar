using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace HomeWork.Manareg
{
public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera PersonFollow;
    [SerializeField] float TimeToChangeStep;
    [SerializeField] float TimerFinish;
    [SerializeField] private int numberOfTeam = 0;
    [SerializeField] List<SpawnManager> listOfTeam = new List<SpawnManager>();


    void Start()
    { 
            PersonFollow = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimerForChangeStep();
    }

   
    
    public void TimerForChangeStep()
    {
        var second = Time.deltaTime;
        TimerFinish += second;
           
            if (TimerFinish>=TimeToChangeStep)
        {
            PersonFollow.Follow = listOfTeam[numberOfTeam].ChooseNextPlayer().transform;
            TimerFinish = 0;    
           // numberOfTeam ++;
            if (numberOfTeam == listOfTeam.Count-1 ) numberOfTeam = 0;
                else { numberOfTeam++; }

                listOfTeam[numberOfTeam].ChooseNextPlayer();
            }
       
    }
}
}

