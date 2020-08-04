using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static  CameraManager Instance;
    private Animator _animator;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _animator = GetComponent<Animator>();
    }


    public void CameraShake()
    {
        _animator.SetTrigger("CameraShake");
    }
}
