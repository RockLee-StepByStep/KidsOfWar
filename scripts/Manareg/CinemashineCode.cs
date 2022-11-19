using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemashineCode : MonoBehaviour
{
    [SerializeField] CinemachineBrain brainCinema;
    [SerializeField] ICinemachineCamera CinemachineCameras;
    [SerializeField] ICinemachineCamera CinemachineCamerasB;

    // Start is called before the first frame update
    void Start()
    {
        brainCinema.SetCameraOverride(2, CinemachineCameras, CinemachineCamerasB, 300, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
