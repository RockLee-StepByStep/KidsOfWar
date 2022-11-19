using System.Collections.Generic;
using UnityEngine;


namespace HomeWork.Manareg
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] GameObject prefub;
        //������ ����������
        [SerializeField] List<GameObject> players = new List<GameObject>(4);
        //������ ����� �������� 
        [SerializeField] List<Transform> ListForPoints = new List<Transform>();

        int count = 4;


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
            Manager.MoveControl(players[numberOfPlayer]);
        }
        private void GetPointsListPosition()
        {
            var Listic = GetComponentsInChildren<Transform>();
            //��������� ������ ����� ��� ��������� ���������� � ������ ��������
            ListForPoints.AddRange(Listic);
        }

        private void GetThisPlayers()
        {
            for (int i = 0; i < count; i++)
            {
                GameObject both = Instantiate(prefub, ListForPoints[i + 1].position, ListForPoints[i].rotation);
                players.Add(both);
            }
        }


        public GameObject ChooseNextPlayer()
        {
           
            numberOfPlayer += 1;
            if (numberOfPlayer == players.Count) numberOfPlayer = 0;
            return players[numberOfPlayer];
        }

        
    }
}
