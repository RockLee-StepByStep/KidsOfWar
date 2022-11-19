using System.Collections.Generic;
using UnityEngine;


namespace HomeWork.Manareg
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] GameObject prefub;
        //Список персонажей
        [SerializeField] List<GameObject> players = new List<GameObject>(4);
        //Список точек респавна 
        [SerializeField] List<Transform> ListForPoints = new List<Transform>();

        int countOfCharacterInOneTeam = 4;


        private PlayerManager Manager;
        [SerializeField] private int numberOfPlayer = 0;

        void Start()
        {
            GetPointsListPosition();
            GetThisPlayers();
            Manager = FindObjectOfType<PlayerManager>();
        }
        private void Update()
        {
            
        }
        private void GetPointsListPosition()
        {
            var Listic = GetComponentsInChildren<Transform>();
            //Добавляем список точек для появления персонажей в точках респавна
            ListForPoints.AddRange(Listic);
        }

        private void GetThisPlayers()
        {
            for (int i = 0; i < countOfCharacterInOneTeam; i++)
            {
                GameObject both = Instantiate(prefub, ListForPoints[i + 1].position, ListForPoints[i].rotation);
                players.Add(both);
            }
        }


        public GameObject ChooseNextPlayer()
        {
            Manager.MoveControl(players[numberOfPlayer]);
            numberOfPlayer += 1;
            if (numberOfPlayer == players.Count) numberOfPlayer = 0;
            return players[numberOfPlayer];
        }

        
    }
}
