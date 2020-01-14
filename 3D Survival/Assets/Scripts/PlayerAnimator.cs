using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is the Player Animator script.
This script handles triggering all player animations.
Removing this script will not break anything.
Requires Animator component.
*/

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    public bool isMoving;
    public bool isWaving;
    public bool isIdle;

    private Animator _animator;


    private void Start() {
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        if(isMoving)
            _animator.SetBool("Move", true);
        else
            _animator.SetBool("Move", false);

        if(isWaving)
            _animator.SetBool("Wave", true);
        else
            _animator.SetBool("Wave", false);
    }
}
