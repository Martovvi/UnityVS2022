using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;
    public int currentCamera = 0;
    
    public void NextCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
        if (currentCamera < cameras.Length)
        { 
            cameras [currentCamera].GetComponent<CinemachineVirtualCamera> ().enabled = true;
            currentCamera++;
        }
    }
}
