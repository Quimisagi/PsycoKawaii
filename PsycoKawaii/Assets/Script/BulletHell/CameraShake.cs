using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Evilness.notifyGameOver += ShakeCamera;
    }

    private void ShakeCamera()
    {
        animator.SetTrigger("Shake");
    }
}
