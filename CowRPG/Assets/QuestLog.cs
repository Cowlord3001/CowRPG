using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour {

    public GameObject Player;
    public GameObject ArenaPlayer;
    public GameObject TutorialPlayer;
    public GameObject[] Arenas;

    public GameObject Overworld;

    [SerializeField]
    public GameObject[] MayorText;
    public GameObject Mayor;

    [SerializeField]
    public GameObject[] TrainerText;
    public GameObject Trainer;

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
        Arenas[0].SetActive(true);
        Overworld.SetActive(false);
        //update dialogue
        Mayor.GetComponent<Chat>().DialogueControl = MayorText[1];
    }
}
