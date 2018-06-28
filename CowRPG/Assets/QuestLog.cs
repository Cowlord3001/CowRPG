using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour {

    public GameObject Player;
    public GameObject ArenaPlayer;
    public GameObject TutorialPlayer;
    public GameObject[] Arenas;

    public GameObject Overworld;
    public GameObject TownExit;

    [SerializeField]
    public GameObject[] MayorText;
    public GameObject Mayor;

    [SerializeField]
    public GameObject[] TrainerText;
    public GameObject Trainer;

    [SerializeField]
    public GameObject[] GuardText;
    public GameObject Guard;

    public static string Class;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseClass(string Class)
    {
        TutorialPlayer.transform.GetChild(0).tag = Class;
        QuestLog.Class = Class;
        Arenas[0].SetActive(true);
        Overworld.SetActive(false);
        //update dialogue
        Mayor.GetComponent<Chat>().DialogueControl = MayorText[1];
        Trainer.GetComponent<Chat>().DialogueControl = TrainerText[1];
        Guard.GetComponent<Chat>().DialogueControl = GuardText[1];
        TownExit.gameObject.SetActive(true);
    }
}
