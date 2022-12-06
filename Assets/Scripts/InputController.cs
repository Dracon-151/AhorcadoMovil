using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputController : MonoBehaviour
{
    [SerializeField] GameObject contenedorPalabra;
    [SerializeField] GameObject contenedorTeclado;
    [SerializeField] GameObject contenedorLetra;
    [SerializeField] GameObject[] ahorcadoFases;
    [SerializeField] TextAsset palabrasPosibles;

    private string palabra;
    private int correctas, incorrectas;

    public void receiveInput(string input)
    {
        Debug.Log("Input: " + input);
        ChecarLetra(input);
    }

    void Start()
    {
        IniciarJuego();
    }

    private void IniciarJuego()
    {
        //Reiniciar al estado original
        correctas = 0;
        incorrectas = 0;

        //Habilita las letras del teclado
        foreach(Button child in contenedorTeclado.GetComponentsInChildren<Button>())
        {
            child.interactable = true;
        }

        //Elimina las letras de la palabra
        foreach(Transform child in contenedorPalabra.GetComponentInChildren<Transform>())
        {
            Destroy(child.gameObject);
        }

        //Desactiva las partes del ahorcado
        foreach(GameObject stage in ahorcadoFases)
        {
            stage.SetActive(false);
        }

        //Genera una nueva palabra
        palabra = generarPalabra().ToUpper();

        foreach(char letra in palabra)
        {
            var temp = Instantiate(contenedorLetra, contenedorPalabra.transform);
        }
    }

    //Esta funcion selecciona una palabra aleatorea de la lista
    private string generarPalabra()
    {
        //Ordena las palabras de la lista en un arreglo
        string[] listaPalabras = palabrasPosibles.text.Split("\n");
        //Selecciona una al azar
        string linea = listaPalabras[Random.Range(0, listaPalabras.Length - 1)];
        //Elimina el "breakline" de la palabra para evitar errores
        return linea.Substring(0, linea.Length - 1);
    }

    //Esta funcion comprueba si la letra se encuentra en la palabra
    private void ChecarLetra(string letra)
    {
        bool letraEnPalabra = false;

        //Recorre la palabra letra por letra para comprobar si hay coincidencias
        for (int i = 0; i < palabra.Length; i++)
        {
            //Si existe una coincidencia aumenta el contador de letras correctas
            if (letra == palabra[i].ToString())
            {
                letraEnPalabra = true;
                correctas++;
                //Muestra las letras correctas en pantalla en la posicion correspondiente
                contenedorPalabra.GetComponentsInChildren<TextMeshProUGUI>()[i].text = letra;
            }
        }

        //Si no hay coincidencias aumenta el contador de incorrectas e imprime la siguiente parte del ahorcado
        if (letraEnPalabra == false)
        {
            incorrectas++;
            ahorcadoFases[incorrectas - 1].SetActive(true);
        }

        //Revisa si se a ganado o perdido
        ComprobarResultado();
    }

    //Esta funcion revisa la condicion de victoria o de perdida.
    private void ComprobarResultado()
    {
        //Si los aciertos son igual a la cantidad de letras en la palabra se gana y se ponen las letras en verde    
        if(correctas == palabra.Length)
        {
            for(int i = 0; i < palabra.Length; i++)
            {
                //Cambia a verde el color de las letras en pantalla
                contenedorPalabra.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.green;
            }

            Invoke("IniciarJuego", 3f);
        }

        //Si las fallas son igual a la cantidad de fases del ahorcado se pierde, las letras se ponen en rojo y se imprimen las letras faltantes
        if(incorrectas == ahorcadoFases.Length)
        {
            for (int i = 0; i < palabra.Length; i++)
            {
                //Cambia a rojo el color de las letras en pantalla
                contenedorPalabra.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.red;

                //Imprime las letras faltantes de la palabra
                contenedorPalabra.GetComponentsInChildren<TextMeshProUGUI>()[i].text = palabra[i].ToString();
            }

            Invoke("IniciarJuego", 3f);
        }
    }
}
