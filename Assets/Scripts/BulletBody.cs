using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBody : MonoBehaviour
{
    private Animator _bulletAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _bulletAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall") | col.CompareTag("EnemyMortal"))
        {
            _bulletAnimator.SetBool("isTouched", true);
        }
    }

    public void OnDestroyAnimationFinished()
    {
        Destroy(this.gameObject);
    }
}
