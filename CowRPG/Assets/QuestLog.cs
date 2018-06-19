using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour {

    public GameObject ArenaPlayer;

    [SerializeField]
    public GameObject[] MayorText;
    public GameObject Mayor;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseClass(string Class)
    {
        ArenaPlayer.transform.GetChild(0).tag = Class;
        //update dialogue
        Mayor.GetComponent<Chat>().DialogueControl = MayorText[1];
    }
}
