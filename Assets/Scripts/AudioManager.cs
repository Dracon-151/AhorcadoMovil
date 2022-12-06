//Script que administra la musica a traves de las escenas
//Creado por Alexis Alvarado.
//Fecha: 05/05/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameObject[] musicObject;

    private AudioSource soundSource;

    private void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);

        soundSource = this.GetComponent<AudioSource>();

        musicObject = GameObject.FindGameObjectsWithTag("AudioManager");
        if (musicObject.Length > 1)
        {
            for (int i = 1; i < musicObject.Length; i++)
            {
                Destroy(musicObject[i]);
            }
        }
    }
}

