using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.IO;


public class PlayEvent : MonoBehaviour
{

    [SerializeField] private PlayableDirector playableDirector;

    [SerializeField] private int ordensMaximas;

    [SerializeField] private List<bool> Isplayermove;

    [SerializeField] private int cenaID;

    private int ordemidatual;

    public int proximaCena;

    public int proximaoOrdem;

    private List<DialogueLine> Dialogos = new List<DialogueLine>();

    private bool IsPlaying = false;


     
    // Start is called before the first frame update
    void Start()
    {
       /* if(ordensMaximas != Isplayermove.Count){
            Debug.LogError("Tamanho das List não bate; ordens e Isplayermove não possuem mesmo tamanho");
        }*/
        ColetaDados();

        foreach (var line in Dialogos)
        {
            Debug.Log($"{line.characterName}: {line.dialogueText}");
        }
    }

    public void ColetaDados(){
        int aux = 0;
        foreach (var item in DialogueManager.dialogueContainer.dialogues)
        {
            if(item.cenaID == cenaID){ 
                Dialogos.Add(item);
            }
        }
    }

    public void PlayingEvent(){
        PlayTimeline();
        IsPlaying = true;
    }

    public bool IsPlayingEvent(){
        return IsPlaying;
    }

    public void ChangeText(){
        if(ordemidatual == null){
            Debug.LogError("Nao possui ordem atual");
        }
        if(Dialogos.Count != 0){
            TextoDialogo.instance.mudarNome(Dialogos[ordemidatual  - 1].characterName);

            TextoDialogo.instance.mudarTexto(Dialogos[ordemidatual - 1].dialogueText);
        }
    }




    public void NextOrder(){

        if(Dialogos[ordemidatual-1].proximaCenaID == cenaID){
            if(Dialogos[ordemidatual - 1].possuiResposta){
                TextoDialogo.instance.gerarRespostas(Dialogos[ordemidatual - 1].opcoes.Count, Dialogos[ordemidatual - 1].opcoes);
            }else{

                ordemidatual = Dialogos[ordemidatual - 1].proximoDialogoID;
            
            }
        }else{
            proximaCena = Dialogos[ordemidatual - 1].proximaCenaID;
            proximaoOrdem = Dialogos[ordemidatual - 1].proximoDialogoID;
            IsPlaying = false;
        }
        
    }
    


    public void SetOrdemIdAtual(int ordemID){
        ordemidatual = ordemID;
    }

    public void Resposta(int resp){
        ordemidatual = Dialogos[ordemidatual - 1].opcoes[resp].proximoDialogoID;
    }

    public void SelecionarResposta(int resp){
        TextoDialogo.instance.DisableRespostas();
        if(Dialogos[ordemidatual-1].opcoes[resp].proximaCenaID == cenaID){
            ordemidatual = Dialogos[ordemidatual - 1].opcoes[resp].proximoDialogoID;
        }else{
            proximaCena = Dialogos[ordemidatual - 1].opcoes[resp].proximaCenaID;
            proximaoOrdem = Dialogos[ordemidatual - 1].opcoes[resp].proximoDialogoID;
            IsPlaying = false;
        }
    }

    public void PlayTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Play();
        }
    }

    public void PauseTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Pause();
        }
    }

    public void ResumeTimeline()
    {
        if (playableDirector != null && playableDirector.state == PlayState.Paused)
        {
            playableDirector.Play();
        }
    }

    public void StopTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Stop();
        }
    }

    public void RewindTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.time = 0;
            playableDirector.Evaluate(); // Avalia a Timeline para atualizar o estado
            playableDirector.Play();
        }
    }

    private DialogueLine SelecionarDialogo(int ordem){
        foreach (var item in Dialogos)
        {
            if(item.id == ordem){
                return item;
            }
        }
        return Dialogos[0];
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
