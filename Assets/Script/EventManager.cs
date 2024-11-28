using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    [SerializeField] private GameController GameController;

    [SerializeField] private int cenaAtual = 1;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(!Events[cenaAtual - 1].IsPlayingEvent()){
            cenaAtual = Events[cenaAtual - 1].NextCene();

            Events[cenaAtual].PlayingEvent();
        } 

        if(NextButton()){
            
        }

        Events[cenaAtual - 1].ChangeText();
    }

    public bool NextButton(){
        return false;
    }
    
}
