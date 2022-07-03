using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
   [SerializeField] private List<string> animState; 
   Animator anim;

    public void StartAnim(int index)
    {
       anim = GetComponent<Animator>();
       anim.Play(animState[index], -1, 0.0f);
    }   
}
