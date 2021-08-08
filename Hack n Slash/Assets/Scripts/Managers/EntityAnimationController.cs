using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private HealthSystemEventChannel eventChannel;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        eventChannel.OnEntityHit += (entity, amount) =>
        {
            if (entity != gameObject) return;
            AnimationHandler("entityhit");
        };
    }

    private void AnimationHandler(string clip)
    {
        animator.Play(clip);
        animator.Play("idle");
    }
}
