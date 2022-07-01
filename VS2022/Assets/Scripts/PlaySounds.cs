using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlaySounds : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    public void PlaySound()
    {
        sound.loop = false;
        sound.Play();
    }
    
    public void PlayLoop()
    {
        sound.loop = true;
        sound.Play();
    }

    public void StopSound()
    {
        sound.loop = false;
        sound.Stop();
    }
}
