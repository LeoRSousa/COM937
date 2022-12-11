using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{
    private TextMeshProUGUI[] _textList;
    
    //Var do player
    //vida é o total de HP atual que pode ser aumentada por cura até a vida máxima. vidaMax é o valor máximo de vida que pode ser aumentado por itens. _dano é a qtd de dano que o player dá.
    private Hero _hero;
    private int vida;
    private int vidaMax;
    private int _dano;

    //Var da nave
    private int _shipPart = 0;

    // Start is called before the first frame update

    void Start()
    {
        vida = PlayerPrefs.GetInt("vidaQt");
        vidaMax = PlayerPrefs.GetInt("vidaMax");
        _dano = PlayerPrefs.GetInt("PlayerDano");
        _textList = FindObjectsOfType<TextMeshProUGUI>();
        _hero = FindObjectOfType<Hero>();
        AttView();
    }

    /*private void Update()
    {
        PlayerPrefs.SetInt("vidaQt", vida);
        PlayerPrefs.SetInt("vidaMax", vidaMax);
        PlayerPrefs.SetInt("PlayerDano", _dano);
    }*/

    /// <summary>
    /// Muda os valores da vida e da vida máxima
    /// </summary>
    /// <param name="type">Campo a ser modificado. "Life" para dano e cura, "LifeMax" para vida máxima. "Dano" aumenta o dano que o player causa.</param>
    public void SetValue(string type)
    {
        switch (type)
        {
            case "Life":
            {
                
                foreach (var elem in _textList)
                {
                    if (elem.name == "LabelVidaQt")
                    {
                        elem.text = PlayerPrefs.GetInt("vidaQt").ToString();
                    }
                }
                break;
            }
            case "LifeMax":
            {
                
                foreach (var elem in _textList)
                {
                    if (elem.name == "LabelVidaMax")
                    {
                        elem.text = PlayerPrefs.GetInt("vidaMax").ToString();
                    }
                }
                break;
            }
            case "Dano":
            {
                
                foreach (var elem in _textList)
                {
                    if (elem.name == "LabelDanoQt")
                    {
                        elem.text = PlayerPrefs.GetInt("PlayerDano").ToString();
                    }
                }
                break;
            }
            default:
                break;
        }
    }
    
    public void TomaDano(int val)
    {
        vida -= val;
        PlayerPrefs.SetInt("vidaQt", vida);
        SetValue("Life");
        if (vida <= 0) Morte();
        StartCoroutine(_hero.DanoCoroutine());
    }

    /// <summary>
    /// Dá play na animação de morte e liga a tela de morte.
    /// </summary>
    public void Morte()
    {
        _hero.playerAnimator.SetBool("isDeath", true);
        _hero._death.SetActive(true);
    }

    /// <summary>
    /// Caso a vida já estiver cheia, sai da função. Se não, aumenta a vida e atualiza a UI.
    /// </summary>
    public void Cura()
    {
        if (vida >= vidaMax) return;
        vida++;
        PlayerPrefs.SetInt("vidaQt", vida);
        SetValue("Life");
    }

    public void AddLife()
    {
        vidaMax++;
        PlayerPrefs.SetInt("vidaMax", vidaMax);
        SetValue("LifeMax");
    }

    public void AddDano()
    {
        _dano++;
        PlayerPrefs.SetInt("PlayerDano", _dano);
        SetValue("Dano");
    }

    public void AddShipParts()
    {
        if(_shipPart == 3) return;
        _shipPart++;
    }

    private void AttView()
    {
        SetValue("Life");
        SetValue("LifeMax");
        SetValue("Dano");
    }
}
