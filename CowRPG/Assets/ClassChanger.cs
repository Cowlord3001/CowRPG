using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassChanger : MonoBehaviour {

    public GameObject TutorialPlayer;
    public GameObject Overworld;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeClass(string Class)
    {
        TutorialPlayer.transform.GetChild(0).tag = Class;
    }

    public void ExitTutorial()
    {
        Overworld.SetActive(true);
        //GameObject.Find("ClassTrainer").transform.GetChild(0).GetComponent<Chat>().DialogueControl.SetActive(false);
        GameObject.Find("Trainer_Text").SetActive(false);
        GameObject.Find("Player").GetComponent<NewMovement>().freezeoff();
        QuestLog.Class = TutorialPlayer.tag;
        gameObject.SetActive(false);
        Debug.Log("GameObject False");
    }
}
