using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayHitAnimation()
    {
        PlayAnimation("entityhit");
    }

    private void PlayAnimation(string clip)
    {
        animator.Play(clip);
        animator.Play("idle");
    }
}
