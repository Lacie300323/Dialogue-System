using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void OnTriggerEnter2D(Collider2D other)
    {
        SimpleMovement playerMovement = other.gameObject.GetComponent<SimpleMovement>(); //Getting Simplemovement Game Component

        if (playerMovement == null) //Checking if the character running into the trigger has a Simplemovement script
        {
            return;
        }

        playerMovement.SetMoving(false); //Turn off the simplemovement script.
        DialogueManager.instance.StartDialogue(dialogue); //Start the Dialogue Queue using the Dialogue Manager singleton

        //characterController.GetComponent<SimpleMovement>().enabled = false;
        Cursor.visible = true;
    }


}
