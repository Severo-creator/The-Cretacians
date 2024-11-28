using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoDialogo : MonoBehaviour
{
    public static TextoDialogo instance {get; private set; }
    [SerializeField] private Text texto;

    [SerializeField] private Text Name;

    private void Awake(){
        if (instance != null){
            Debug.LogError("Found more than one TextoDialogo in the scene.");
        }
        instance = this;
    }

    public void mudarTexto(string info){
        texto.text = info;
    }

    public void mudarNome(string info){
        Name.text = info;
    }
}
