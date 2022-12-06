using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordCounter : MonoBehaviour
{
    [SerializeField] private string id;
    private TextMeshProUGUI texto;

    private void Start()
    {
       texto = this.GetComponent<TextMeshProUGUI>();   
    }
    void Update()
    {
        texto.text = "" + PlayerPrefs.GetInt(id);
    }
}
