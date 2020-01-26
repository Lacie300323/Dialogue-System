using System.Collections;
using UnityEngine.Events; //making use of the Unity Events system
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public UnityEvent OnDialogueEnd = new UnityEvent();

    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueText;

    public Animator anim;
    public static DialogueManager instance; //Making a Singleton

    //Keeps track of all of the sentences withing the Dialogue System. Get System.Collections; to make Queue usable.
    /// <summary>
    /// Using a Queue instead of an array, because it's an restricted list. It only will only use the sentences
    /// I want to display in the list of the Queue and will load new sentences once the dialogue is loaded again.
    /// Using a Queue made out of sentences since it's a dialogue system.
    /// </summary>
    public Queue<string> sentences;

    void Awake() //Checks for stuff before the start method.
    {
        if (instance != null && this != instance) //instance != null can also be (!instance). Means the same thing. 
        {
            Debug.LogError("There was more than one Dialogue Manager");
            this.enabled = false;
            return;
        }
        DialogueManager.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear(); // Clear the sentences from the previous dialogue

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); //Put in the sentences in the dialogue sentences variables
        }
        DisplayNextSentence();
        //Debug.Log("Starting conversation with " + dialogue.name);
    }

    public void DisplayNextSentence()
    {
        anim.SetBool("isOpen", true);

        if(sentences.Count == 0) //Is the sentence count equal to the last sentence in the queue
        {

        EndDialogue(); //End the dialogue
        return;

        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        OnDialogueEnd.Invoke(); //Call this "ondialogueEnd" event
        anim.SetBool("isOpen", false);
        Debug.Log("End of Conversation");   
    }
}
