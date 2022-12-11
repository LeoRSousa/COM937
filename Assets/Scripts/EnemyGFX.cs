using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    private Animator enemy;
    private Hero _hero;

    private void Start()
    {
        enemy = GetComponent<Animator>();
        _hero = FindObjectOfType<Hero>();
    }

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Hero")
        {
            enemy.SetBool("isTouching", true);
            _hero._life.TomaDano(8);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemy.SetBool("isTouching", false);
    }
}
