using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance {get; private set; }
    public string jsonFileName = "Dialogos/NPCDialogues/dialogos.json";
    public static DialogueContainer dialogueContainer;

    private void Awake(){
        instance = this;

        LoadDialogue();
        foreach (var line in dialogueContainer.dialogues)
        {
            Debug.Log($"{line.characterName}: {line.dialogueText}");
        }
    }


    void LoadDialogue()
    {
        string filePath = Path.Combine(Application.dataPath, jsonFileName);
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            dialogueContainer = JsonUtility.FromJson<DialogueContainer>(jsonData);
        }
        else
        {
            Debug.LogError($"Arquivo JSON não encontrado em: {filePath}");
        }
    }
}
