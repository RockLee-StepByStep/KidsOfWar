using System.Collections.Generic;
using Cinemachine;
using Core;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private List<SpawnManager> _listOfTeam = new List<SpawnManager>();
        [SerializeField] private float _timeToChangeStep;

        private CinemachineVirtualCamera _personFollow;
        private float _timerFinish;
        private int _numberOfTeam = 0;


        private void Start()
        {
            _personFollow = GetComponent<CinemachineVirtualCamera>();
        }

        private void Update()
        {
            TimerForChangeStep();
        }

        private void TimerForChangeStep()
        {
            var second = Time.deltaTime;
            _timerFinish += second;

            if (_timerFinish >= _timeToChangeStep)
            {
                _personFollow.Follow = _listOfTeam[_numberOfTeam].ChooseNextPlayer().transform;
                _timerFinish = 0;
                
                if (_numberOfTeam == _listOfTeam.Count - 1)
                {
                    _numberOfTeam = 0;
                }
                else
                {
                    _numberOfTeam++;
                }

                _listOfTeam[_numberOfTeam].ChooseNextPlayer();
            }
        }
    }
}