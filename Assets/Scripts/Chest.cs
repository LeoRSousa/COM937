using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Random = System.Random;

public class Chest : MonoBehaviour
{
    public enum Items {Espada, Machado, Escudo, Poção, Fogo}
    private Animator chestAnimator;

    private Hero _hero;

    private Thread addItem;

    private Items currentItem;
    // Start is called before the first frame update
    void Start()
    {
        chestAnimator = GetComponent<Animator>();
        _hero = FindObjectOfType<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Caso o baú não esteja aberto, ele irá dar um item aleatório para o player
        if (!chestAnimator.GetBool("isOpen"))
        {
            var values = Enum.GetValues(typeof(Items));
            var rdn = (Items)values.GetValue(new Random().Next(values.Length));
            //currentItem = rdn;
            print("Rdn: " + rdn);
            _hero.AddItem(rdn.ToString());
            //addItem = new Thread(AddItem);
            //addItem.Start();
        }
        chestAnimator.SetBool("isOpen", true);
    }

    //private void AddItem()
    //{
        //_hero.AddItem(currentItem);
    //}
    
    //private Items 
}
