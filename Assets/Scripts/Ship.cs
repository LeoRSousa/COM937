using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    private GameObject dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.FindWithTag("ShipPartDialogue");
        dialogue.SetActive(false);
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
                SceneManager.LoadScene(7);

            }
            else
            {
                //Avisa que ainda faltam partes
                StartCoroutine(ItemDialogue());
            }
        }
    }
    private IEnumerator ItemDialogue()
    {
        dialogue.SetActive(true);
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
    }
}
