using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



[System.Serializable]
public class OpcaoDeResposta
{
    public string resposta; // Texto da resposta
    public int proximoDialogoID; // ID do próximo diálogo associado
    public int proximaCenaID;
    
}


[System.Serializable]
public class DialogueLine
{
    public int id;
    public int cenaID;
    public int proximaCenaID;
    public int proximoDialogoID;
    public string characterName;
    public string dialogueText;

    public bool possuiResposta;

    public List<OpcaoDeResposta> opcoes;

}
