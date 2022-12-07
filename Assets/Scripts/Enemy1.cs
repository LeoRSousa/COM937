using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Rigidbody2D enemyRb;
    [SerializeField] float enemyVelocidade = 2;
    private SpriteRenderer mySpriteRenderer;
    private Hero _hero;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        _hero = FindObjectOfType<Hero>();
    }

    void Update()
    {
        Mover();
    }

    void Mover(){
        enemyRb.velocity = new Vector2(enemyVelocidade,enemyRb.velocity.y);
    }
    
    void FlipSprite()
    {
        mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Hero")
        {
            _hero.TomaDano(1);
        }
        enemyVelocidade = -enemyVelocidade;
        FlipSprite();
    }

    //void OnTriggerExit2D(Collider2D other) {
    //    enemyVelocidade = -enemyVelocidade;
    //   FlipSprite();
    //}
}
