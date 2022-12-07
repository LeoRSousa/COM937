using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    public void SetDamage(string value)
    {
        _textMeshProUGUI.text = value;
    }
}
