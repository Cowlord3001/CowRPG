using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour {

    public GameObject DialogueControl;
    bool Chatting;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Return) && Chatting == false)
        {
           Invoke("StartDialogue", .05f);
           collision.gameObject.SendMessage("togglefreeze");
        }
        else if (DialogueControl.activeSelf == false)
        {
            Chatting = false;
        }
    }

    void StartDialogue()
    {
        DialogueControl.SetActive(true);
        Chatting = true;
    }
}
