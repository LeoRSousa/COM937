using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class ChestShip : MonoBehaviour
{
    private Animator chestAnimator;

    private Hero _hero;
    private GameObject _dialogue;

    [SerializeField] private int shipPart = 0;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    // Start is called before the first frame update
    void Start()
    {
        chestAnimator = GetComponent<Animator>();
        _hero = FindObjectOfType<Hero>();
        _dialogue = GameObject.FindWithTag("ShipPartDialogue");
        _dialogue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name != "Hero") return;
        
        //Caso o baú não esteja aberto, ele irá dar uma parte da nave
        if (!chestAnimator.GetBool(IsOpen))
        {
            StartCoroutine(ItemDialogue());
            _hero._life.AddShipParts(shipPart);
            //_hero.SetCarringValues(true, shipPart);
        }
        chestAnimator.SetBool(IsOpen, true);
    }
    
    private IEnumerator ItemDialogue()
    {
        _dialogue.SetActive(true);
        yield return new WaitForSeconds(3);
        _dialogue.SetActive(false);
    }
}