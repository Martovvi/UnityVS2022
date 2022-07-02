using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
    public GameObject[] cameras;
    public int currentIndex = 0;
    [SerializeField] private GameObject prevButton;
    [SerializeField] private GameObject nextButton;

    void Awake()
    {
        if (cameras.Length > 0)
        {
            for (int i = 1; i < cameras.Length; ++i)
            {
                cameras[i].SetActive(false);
            }
        }
        prevButton.SetActive(false);
    }
    
    public int CurrentIndex
    {
        get
        {
            return currentIndex;
        }
        set
        {
            if (cameras[currentIndex] != null)
            {
                //set the current active object to inactive, before replacing it
                GameObject activeObj = cameras[currentIndex];
                activeObj.SetActive(false);
            }

            if (value < 0)
            {
                currentIndex = 0;
            }
            
            else if (value > cameras.Length - 1)
            {
                currentIndex = cameras.Length -1;
            }
            else
            {
                currentIndex = value;
            }
            if (cameras[currentIndex] != null)
            {
                GameObject activeObj = cameras[currentIndex];
                activeObj.SetActive(true);
            }

            if (currentIndex == 0)
            {
                prevButton.SetActive(false);
            }
            else if (currentIndex == cameras.Length -1)
            {
                nextButton.SetActive(false);
            }
            else
            {
                prevButton.SetActive(true);
                nextButton.SetActive(true);
            }
            
            
        }
    }
    
    public void Next(int direction)
    {
        if (direction == 0)
            CurrentIndex--;
        else
            CurrentIndex++;
    }
    
}
