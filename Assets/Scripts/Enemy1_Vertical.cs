using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Vertical : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        Mover();
    }
    
    void Mover()
    {
        enemyRb.velocity = new Vector2(enemyRb.velocity.x, enemyVelocidade);
    }
    
    void FlipSprite()
    {
        mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Hero")
        {
            _hero._life.TomaDano(1);
        }
        enemyVelocidade = -enemyVelocidade;
        FlipSprite();
    }
}