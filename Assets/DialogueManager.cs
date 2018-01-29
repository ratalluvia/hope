using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> phrases;

    void Start () {
        phrases = new Queue<string>();
	}
	
	public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        phrases.Clear();

        foreach(string phrase in dialogue.phrases)
        {
            phrases.Enqueue(phrase);
        }

        DisplayNextPhrase();
    }

    public void DisplayNextPhrase()
    {
        if (phrases.Count == 0)
        {
            EndDialogue();
            return;
        }

        string phrase = phrases.Dequeue();
        dialogueText.text = phrase;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
    }
}
