using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;    // Queue to hold the sentences of the dialogue

    void Start()
    {
        sentences = new Queue<string>();    // Initialize the queue
    }

    void Update()
    {
        
    }
}
