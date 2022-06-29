using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartAlembic : MonoBehaviour
{
    [SerializeField] private GameObject fluid;
    PlayableDirector director;


    public void StartFluidAnim()
    {
       director = fluid.GetComponent<PlayableDirector>();
       director.Play();
    }

    public void ObjectDisappear()
    {

    }

    public void PlaySound()
    {
        
    }
}
