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

        private CinemachineVirtualCamera _camera;
        private float _timerFinish;
        private int _numberOfTeam = 0;


        private void Start()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
            _camera.Follow = _listOfTeam[0].GetFirstPlayer().transform;
            _listOfTeam[0].TurnNow = true;
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
                _timerFinish = 0;
                
                if (_numberOfTeam == _listOfTeam.Count - 1)
                {
                    _numberOfTeam = 0;
                }
                else
                {
                    _numberOfTeam++;
                }
                
                var nextPlayer = _listOfTeam[_numberOfTeam].ChooseNextPlayer();
                _camera.Follow = nextPlayer.transform;

                for (var i = 0; i < _listOfTeam.Count; i++)
                {
                    _listOfTeam[i].TurnNow = i == _numberOfTeam;
                }
            }
        }
    }
}