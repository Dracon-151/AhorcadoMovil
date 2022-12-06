using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void changeScene(int id)
    {
        PlayerPrefs.SetInt("words", 0);

        SceneManager.LoadScene(id);
    }
}
