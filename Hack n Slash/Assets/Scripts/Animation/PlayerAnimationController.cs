using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles animation for the entity.
/// </summary>
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayHitAnimation(int damage)
    {
        PlayAnimation("entityhit");
    }

    private void PlayAnimation(string clip)
    {
        animator.Play(clip);
        animator.Play("idle");
    }
}
