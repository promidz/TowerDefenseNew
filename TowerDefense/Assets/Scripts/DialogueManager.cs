using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public WaveSpawner wavespawner;
    public Bosses boss;


    private Queue<string> sentences;
	// Use this for initialization
	void Awake () {
        sentences = new Queue<string>();
	}
	
	public void StartDialogue(Dialogue dialogue)
    {

        boss.onDialog = true;
        wavespawner.onDialog = true;
        //Time.timeScale = 0;
        animator.SetBool("IsOpen", true);
        Debug.Log("Starting conversation with" + dialogue.name);
        //sets npc name
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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
        //remove oldest element in the queue
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; 
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);

        }
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        boss.onDialog = false;
        wavespawner.onDialog = false;
    }
}
