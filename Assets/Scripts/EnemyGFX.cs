using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    private Animator enemy;

    private void Start()
    {
        enemy = GetComponent<Animator>();
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
        print("Modo de combate");
        enemy.SetBool("isTouching", true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemy.SetBool("isTouching", false);
    }

    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Hero")
        {
            enemy.SetBool("isTouching", true);
            print("Modo de combate");
        }
    }*/
}
