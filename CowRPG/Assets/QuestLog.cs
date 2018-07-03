using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text CurrentQuest;

    public static string Class;
    public static int Progress;
    static int EXP;
    static int Level;

	// Use this for initialization
	void Start () {
        Class = "Ranger";
        Progress = 0;
        EXP = 0;
        Level = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //0
    public void PostMayorTalk()
    {
        CurrentQuest.text = "-Talk to the Class Trainer and Pick a Class";
        Progress = 1;
    }

    //1
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
        CurrentQuest.text = "-Find the <B>Monster</B> in the Forest Depths";
        Progress = 2;
    }

    public static void AddEXP(int n)
    {
        EXP = EXP + n;
        Debug.Log("Current EXP = " + EXP);
        if(EXP >= 500 && EXP < 1100)
        {
            Level = 2;
        }
        else if (EXP >= 1100 && EXP < 2700)
        {
            Level = 3;
        }
        else if (EXP >= 2700 && EXP < 6500)
        {
            Level = 4;
        }
        else if (EXP >= 6500)
        {
            Level = 5;
        }
    }
}
