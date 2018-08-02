using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour {

    public GameObject DialogueControl;
    bool Chatting;
  
    public bool Event;

    public QuestLog QuestLog;

    public GameObject Arena;
    bool TalkedTo;

	// Use this for initialization
	void Start () {
        TalkedTo = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Return) && Chatting == false)
        {
           Invoke("StartDialogue", .05f);
           collision.gameObject.SendMessage("freezeon");
            if (QuestLog.Progress == 0 && gameObject.transform.parent.name == "Mayor")
            {
                QuestLog.PostMayorTalk();
                QuestLog.Progress = 1;
            }
            if(gameObject.transform.parent.name == "Switch")
            {
                gameObject.GetComponentInParent<Switch>().SwitchOn();
            }
        }
        else if (DialogueControl.activeSelf == false)
        {
            Chatting = false;
            if (TalkedTo == true && gameObject.transform.parent.tag == "EnemyNPC")
            {
                EnemyNPCEnabler();
                Destroy(transform.parent.gameObject);
            }
        }
    }

    void EnemyNPCEnabler()
    {
            GameObject.Find("OverWorld").SetActive(false);
            Arena.SetActive(true);
    }

    void StartDialogue()
    {
        TalkedTo = true;
        DialogueControl.SetActive(true);
        Chatting = true;
    }
}

//GameObject.Find("OverWorld Control").GetComponent<QuestLog>().ChooseClass();