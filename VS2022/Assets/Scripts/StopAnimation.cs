using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
  [SerializeField] private string trigger;
  Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    public void StopAnim()
    {
        if (AnimatorIsPlaying())
        {
            animator.SetTrigger(trigger);
        }
    }
}
