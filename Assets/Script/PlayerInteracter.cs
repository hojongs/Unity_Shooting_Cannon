using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracter : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void interact(Action callback)
    {
        if (callback == null)
            return;

        // TODO: common action here

        callback();
    }

    public void die()
    {
        var animator = GetComponent<Animator>();
        Debug.Assert(animator);

        animator.SetBool("die", true);
    }
}
