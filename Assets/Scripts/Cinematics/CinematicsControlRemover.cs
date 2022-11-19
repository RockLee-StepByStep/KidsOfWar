using RPG.Control;
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
public class CinematicsControlRemover : MonoBehaviour
{
        GameObject playerMan;


    // Start is called before the first frame update
    void Start()
    {
            playerMan = GameObject.FindGameObjectWithTag("Player");
            GetComponent<PlayableDirector>().played += DisableScene;
            GetComponent<PlayableDirector>().stopped += EnableScene;
    }

    private void DisableScene(PlayableDirector time)
        {
           playerMan.GetComponent<ActionScheduler>().CancelCurrentAction();
            playerMan.GetComponent<PlayerController>().enabled = false;
        }

    private void EnableScene(PlayableDirector time)
        {
            playerMan.GetComponent<PlayerController>().enabled = true ;
        }
}
}

