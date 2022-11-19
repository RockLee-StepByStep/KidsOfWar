using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Core
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        private readonly List<GameObject> _players = new List<GameObject>(4);
        private readonly List<Transform> _listForPoints = new List<Transform>();

        private const int CountOfCharacterInOneTeam = 4;


        private PlayerManager _manager;
        private int _numberOfPlayer = 0;

        private void Start()
        {
            GetPointsListPosition();
            GetThisPlayers();
            _manager = FindObjectOfType<PlayerManager>();
        }

        private void GetPointsListPosition()
        {
            var list = GetComponentsInChildren<Transform>();
            _listForPoints.AddRange(list);
        }

        private void GetThisPlayers()
        {
            for (int i = 0; i < CountOfCharacterInOneTeam; i++)
            {
                GameObject both = Instantiate(_prefab, _listForPoints[i + 1].position, _listForPoints[i].rotation);
                _players.Add(both);
            }
        }


        public GameObject ChooseNextPlayer()
        {
            _manager.MoveControl(_players[_numberOfPlayer]);
            _numberOfPlayer += 1;
            if (_numberOfPlayer == _players.Count)
            {
                _numberOfPlayer = 0;
            }
            return _players[_numberOfPlayer];
        }
    }
}