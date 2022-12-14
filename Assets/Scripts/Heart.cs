using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Hero _hero;
    
    // Start is called before the first frame update
    void Start()
    {
        _hero = FindObjectOfType<Hero>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _hero._life.AddLife();
        _hero._life.Cura();
        Destroy(this.gameObject);
    }
}
