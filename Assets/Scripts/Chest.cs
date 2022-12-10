using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Random = System.Random;

public class Chest : MonoBehaviour
{
    public enum Items {Espada, Machado, Poção, Fogo}
    private Animator chestAnimator;

    private Hero _hero;
    private GameObject _dialogue;

    private Items currentItem;

    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    // Start is called before the first frame update
    void Start()
    {
        chestAnimator = GetComponent<Animator>();
        _hero = FindObjectOfType<Hero>();
        _dialogue = GameObject.FindWithTag("ItemDialogue");
        _dialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name != "Hero") return;
        //Caso o baú não esteja aberto, ele irá dar um item aleatório para o player
        if (!chestAnimator.GetBool(IsOpen))
        {
            /*var values = Enum.GetValues(typeof(Items));
            var rdn = (Items)values.GetValue(new Random().Next(values.Length));
            _hero.AddItem(rdn.ToString());*/
            StartCoroutine(ItemDialogue());
        }
        chestAnimator.SetBool(IsOpen, true);
    }

    private IEnumerator ItemDialogue()
    {
        _dialogue.SetActive(true);
        yield return new WaitForSeconds(2);
        _dialogue.SetActive(false);
    }

}
