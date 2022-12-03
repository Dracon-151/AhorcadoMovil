using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private string inputString;
    public void receiveInput(string input)
    {
        Debug.Log("Input: " + input);
        inputString += input;
        Debug.Log("String: " + inputString);

    }

}
