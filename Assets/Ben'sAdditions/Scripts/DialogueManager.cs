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

    public Animator animator;

    private Queue<string> sentences;    // Queue to hold the sentences of the dialogue

    void Start()
    {
        sentences = new Queue<string>();    // Initialize the queue
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

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
        StopAllCoroutines();    // Stop any ongoing typing effect so they don't overlap
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;    // Add each letter to the dialogue text one by one
            yield return null;    // Wait for the next frame before adding the next letter
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
