using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class ChestShip : MonoBehaviour
{
    private Animator chestAnimator;

    private Hero _hero;

    [SerializeField] private int shipPart;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    // Start is called before the first frame update
    void Start()
    {
        chestAnimator = GetComponent<Animator>();
        _hero = FindObjectOfType<Hero>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name != "Hero") return;
        
        //Caso o baú não esteja aberto, ele irá dar uma parte da nave
        if (!chestAnimator.GetBool(IsOpen))
        {
            print("Você recebeu uma parte da sua nave!");
        }
        chestAnimator.SetBool(IsOpen, true);
    }
}