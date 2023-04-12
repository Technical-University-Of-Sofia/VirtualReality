using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuttle : MonoBehaviour
{ 
    private Animator animator;
    
    void Awake()
    { 
        animator = GetComponent<Animator>();
    } 
    
    public void OpenDoors()
    { 
        animator.SetTrigger("open");
    } 
}