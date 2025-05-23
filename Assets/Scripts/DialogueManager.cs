using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button continueButton;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
        continueButton.onClick.AddListener(DisplayNextSentence);
    }

    public void StartDialogue(List<string> dialogueLines)
    {
        Debug.Log("Triggering dialogue for wave 3");
        SFXManager.Instance.PlayGruntSound();
        dialoguePanel.SetActive(true);
        sentences.Clear();

        foreach (string line in dialogueLines)
        {
            sentences.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
