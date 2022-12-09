using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{
    private TextMeshProUGUI[] _textList;
    
    // Start is called before the first frame update
    void Start()
    {
        _textList = FindObjectsOfType<TextMeshProUGUI>();
    }

    /// <summary>
    /// Muda os valores da vida e da vida máxima
    /// </summary>
    /// <param name="value">Valor atualizado do campo a modificar</param>
    /// <param name="type">Campo a ser modificado. "Life" para dano e cura, "LifeMax" para vida máxima.</param>
    public void SetValue(string value, string type)
    {
        switch (type)
        {
            case "Life":
            {
                foreach (var elem in _textList)
                {
                    if (elem.name == "LabelVidaQt")
                    {
                        elem.text = value;
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
                        elem.text = value;
                    }
                }
                break;
            }
            default:
                break;
        }
    }
}
