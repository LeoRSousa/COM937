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
    private int _enemyLife = 10;
    private int _danoSofrido;
    private int playerDano = 1;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        _hero = FindObjectOfType<Hero>();
    }

    void Update()
    {
        Mover();
        playerDano = PlayerPrefs.GetInt("PlayerDano");
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
            _hero._life.TomaDano(1);
        }
        
        enemyVelocidade = -enemyVelocidade;
        FlipSprite();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            print("Dano");
            TomaDano();
        }
    }

    private void TomaDano()
    {
        _enemyLife -= playerDano;
        if (_enemyLife == 0)
        {
            print("Morto");
            Destroy(this.gameObject);
        }
    }
}
