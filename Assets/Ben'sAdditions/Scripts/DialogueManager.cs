using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;    // Queue to hold the sentences of the dialogue

    void Start()
    {
        sentences = new Queue<string>();    // Initialize the queue
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);    // Log the name of the character speaking
    }

}
