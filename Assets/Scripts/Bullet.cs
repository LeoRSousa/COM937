using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    //Var do tiro
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPoint;
    

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                Atirar(1);
            }
            else if (Keyboard.current.leftArrowKey.isPressed)
            {
                Atirar(-1);
            }
        }
    }

    void Atirar(float direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shootingPoint.right * (direction * speed), ForceMode2D.Impulse);
    }

    public void DestroyObjectOnCollision()
    {
        
    }
}
