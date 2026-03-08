using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCInteractable : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }
    public void TriggerDialogue()
    {
        Object.FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }
}
