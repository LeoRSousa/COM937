using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator an;
     
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        an.Play(0);
    }
}
