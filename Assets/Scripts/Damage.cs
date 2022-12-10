using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Hero _hero;
    
    // Start is called before the first frame update
    void Start()
    {
        _hero = FindObjectOfType<Hero>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        _hero._life.AddDano();
        Destroy(this.gameObject);
    }
}
