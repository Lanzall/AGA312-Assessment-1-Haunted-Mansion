using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCInteractable : MonoBehaviour
{
    public Dialogue dialogue;

    public Animator animator;
    private bool hasInteracted;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        hasInteracted = false;
    }
    public void TriggerDialogue()
    {
        if (hasInteracted)
        {
            return;
        }

        Object.FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
        hasInteracted = true;
        animator.SetBool("CanInteract", false);
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
        if (hasInteracted)
        {
            return;
        }
        animator.SetBool("CanInteract", true);
    }

    public void CanTalkFalse()
    {
        animator.SetBool("CanInteract", false);
    }
}
