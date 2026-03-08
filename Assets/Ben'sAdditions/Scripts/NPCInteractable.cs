using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCInteractable : MonoBehaviour
{
    public Dialogue dialogue;

    public bool hasInteracted;

    public Animator animator;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        hasInteracted = false;
    }
    public void TriggerDialogue()
    {
        Object.FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

    public void ContinueDialogue()
    {
        Object.FindFirstObjectByType<DialogueManager>().DisplayNextSentence();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            {
                ContinueDialogue();
        }
    }

    public void CanTalkTrue()
    {
        animator.SetBool("CanInteract", true);
    }

    public void CanTalkFalse()
    {
        animator.SetBool("CanInteract", false);
    }
}
