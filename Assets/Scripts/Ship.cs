using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Hero")
        {
            int SP1 = PlayerPrefs.GetInt("SP1");
            int SP2 = PlayerPrefs.GetInt("SP2");
            int SP3 = PlayerPrefs.GetInt("SP3");

            if (SP1 == 1 & SP2 == 1 & SP3 == 1)
            {
                //Chama a cena final aqui
            }
            else
            {
                //Avisa que ainda faltam partes
                print("Vc não tds partes ainda");
            }
        }
    }
}
