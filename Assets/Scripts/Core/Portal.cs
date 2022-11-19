using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Core
{
public class Portal : MonoBehaviour
{
        enum DestynationWay
        {
            A,B,C,D
        }

        [SerializeField] Transform SpawnPoint;
        [SerializeField] int numberOfLvl;
        [SerializeField] DestynationWay destynation;

        private void OnTriggerEnter(Collider Player)
        {
            if (Player.CompareTag("Player"))
            {
                StartCoroutine(Transition());
            }
        }

        private IEnumerator Transition()
        {

            DontDestroyOnLoad(gameObject);
            yield return SceneManager.LoadSceneAsync(numberOfLvl);

            
            
            Portal getOtherPortal = GetSpawnPoint();
            UpdatePlayerPosition(getOtherPortal);

            Destroy(gameObject);
        }

        private Portal GetSpawnPoint()
        {
            foreach (Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this)
                {
                    continue;
                }
                if (portal.destynation != destynation)
                {
                    continue;
                }
                return portal;
            }
            return null;
        }

        private void UpdatePlayerPosition(Portal getOtherPortal)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = getOtherPortal.SpawnPoint.position;
            player.transform.rotation = getOtherPortal.SpawnPoint.rotation;
        }

       
    }

    
}

