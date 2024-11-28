using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.IO;


public class PlayEvent : MonoBehaviour
{

    [SerializeField] private PlayableDirector timeline;

    [SerializeField] private int ordensMaximas;

    [SerializeField] private List<bool> Isplayermove;

    [SerializeField] private int cena;

    private int ordemAtual = 1;

    private List<DialogueLine> Dialogos = new List<DialogueLine>();

    private bool IsPlaying = false;

 

     
    // Start is called before the first frame update
    void Start()
    {
        if(ordensMaximas != Isplayermove.Count){
            Debug.LogError("Tamanho das List não bate; ordens e Isplayermove não possuem mesmo tamanho");
        }
        ColetaDados();

        foreach (var line in Dialogos)
        {
            Debug.Log($"{line.characterName}: {line.dialogueText}");
        }
    }

    public void ColetaDados(){

        foreach (var item in DialogueManager.dialogueContainer.dialogues)
        {
            if(item.cena == cena){
                Dialogos.Add(item);
            }
        }
    }

    public void PlayingEvent(){
        IsPlaying = true;
    }

    public int NextCene(){

        return 2;
    }

    public bool IsPlayingEvent(){
        return IsPlaying;
    }

    public void ChangeText(){
        TextoDialogo.instance.mudarNome(Dialogos[ordemAtual - 1].characterName);

        TextoDialogo.instance.mudarTexto(Dialogos[ordemAtual - 1].dialogueText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
