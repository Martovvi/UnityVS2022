using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
  Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StopAnim()
    {
        anim.enabled = false;
    }
}
