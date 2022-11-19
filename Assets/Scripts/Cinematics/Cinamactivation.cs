using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
public class Cinamactivation : MonoBehaviour
{
        private bool _TrigerHasActivated = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!_TrigerHasActivated && other.CompareTag("Player"))
            {
                GetComponent<PlayableDirector>().Play();
                _TrigerHasActivated = true;
            }
        }
    }
}

