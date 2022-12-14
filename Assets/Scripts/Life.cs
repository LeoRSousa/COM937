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

    //Var da parte nave
    private int _shipPart1 = 0;
    private int _shipPart2 = 0;
    private int _shipPart3 = 0;

    // Start is called before the first frame update

    void Start()
    {
        vida = PlayerPrefs.GetInt("vidaQt");
        vidaMax = PlayerPrefs.GetInt("vidaMax");
        _dano = PlayerPrefs.GetInt("PlayerDano");
        _textList = FindObjectsOfType<TextMeshProUGUI>();
        _hero = FindObjectOfType<Hero>();
        AttView();
        _shipPart1 = PlayerPrefs.GetInt("SP1"); 
        _shipPart2 = PlayerPrefs.GetInt("SP2");
        _shipPart3 = PlayerPrefs.GetInt("SP3");
    }

    

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
        if(vida <= 0)
            vida = 0;
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
        _hero.Morrer();
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

    public void AddShipParts(int part)
    {
        switch (part)
        {
            case 1:
                PlayerPrefs.SetInt("SP1", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("SP2", 1);
                break;
            case 3:
                PlayerPrefs.SetInt("SP3", 1);
                break;
            default:
                break;
        }
    }
    
    public void RemoveShipParts(int part)
    {
        switch (part)
        {
            case 1:
                PlayerPrefs.SetInt("SP1", 0);
                break;
            case 2:
                PlayerPrefs.SetInt("SP2", 0);
                break;
            case 3:
                PlayerPrefs.SetInt("SP3", 0);
                break;
            default:
                break;
        }
    }

    private void AttView()
    {
        SetValue("Life");
        SetValue("LifeMax");
        SetValue("Dano");
    }
}
