using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
   [SerializeField] private List<string> animState; 
   Animator anim;

    public void StopAnim(int index)
    {
       anim = GetComponent<Animator>();
       anim.Play(animState[index], -1, 1.0f);
    }   
}
