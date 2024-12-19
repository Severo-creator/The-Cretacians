using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    [SerializeField] private GameController GameController;

    [SerializeField] private int cenaAtual = 1;

    [SerializeField] private int ordem = 1;

    [SerializeField] private List<PlayEvent> Events = new List<PlayEvent>();


    


    // Start is called before the first frame update
    void Start()
    {
        PlayEvent[] children = GetComponentsInChildren<PlayEvent>();

        foreach (PlayEvent child in children)
        {
            Events.Add(child);
        }
        //List<PlayEvents>
        Events[cenaAtual - 1].PlayingEvent(); 
        Events[cenaAtual - 1].SetOrdemIdAtual(ordem);
    }

    // Update is called once per frame
    void Update()
    {
        if(!Events[cenaAtual - 1].IsPlayingEvent()){

            Debug.Log("0MG");

            ordem = Events[cenaAtual - 1].proximaoOrdem;
            cenaAtual = Events[cenaAtual - 1].proximaCena;

            Events[cenaAtual - 1].PlayingEvent();
            Events[cenaAtual - 1].SetOrdemIdAtual(ordem);
        } 


        Events[cenaAtual - 1].ChangeText();
    }

    public void NextButton(){
        Events[cenaAtual - 1].NextOrder();
    }

    public void ResponderButton(int resp){
        Events[cenaAtual - 1].SelecionarResposta(resp);
    }

    
    
}
