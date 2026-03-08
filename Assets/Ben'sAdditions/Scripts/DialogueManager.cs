using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;    // Queue to hold the sentences of the dialogue

    void Start()
    {
        sentences = new Queue<string>();    // Initialize the queue
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;    // Display the name of the character in the UI

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);    // Add each sentence to the queue
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();    // Remove the next sentence from the queue
        dialogueText.text = sentence;    // Display the sentence in the dialogue text UI

    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");    // Log the end of the conversation
    }
}
