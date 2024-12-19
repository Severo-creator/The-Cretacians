
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoDialogo : MonoBehaviour
{
    public static TextoDialogo instance {get; private set; }
    
    [SerializeField] private Text texto;

    [SerializeField] private Text Name;

    [SerializeField] private Transform buttonNext;

    [SerializeField] private Transform RespostasTransform;

    private List<Transform> listaRespostas = new List<Transform>();

    private void Awake(){
        if (instance != null){
            Debug.LogError("Found more than one TextoDialogo in the scene.");
        }
        instance = this;
        Transform[] children = RespostasTransform.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if(child.gameObject.CompareTag("Texto")){
                listaRespostas.Add(child);
                Debug.Log("int");
            }
        }
    }

    public void mudarTexto(string info){
        texto.text = info;
    }

    public void mudarNome(string info){
        Name.text = info;
    }

    public void gerarRespostas(int numeroRespostas, List<OpcaoDeResposta> Respostas){
        RespostasTransform.gameObject.SetActive(true);
        int aux = 0;
        if(numeroRespostas == 3){
            foreach (var item in Respostas)
            {
                trocarTextoBotao(listaRespostas[aux], item.resposta);
                aux++;
            }
        }else if(numeroRespostas == 2){

        }else if(numeroRespostas == 1){

        }
    }

    public void DisableRespostas(){
        RespostasTransform.gameObject.SetActive(false);
    }

    private void trocarTextoBotao(Transform botao, string txt){
        Text textoBotao =  botao.GetComponent<Text>();

        textoBotao.text = txt;
    }
}
