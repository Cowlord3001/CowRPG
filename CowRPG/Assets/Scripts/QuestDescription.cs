using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDescription : MonoBehaviour {

    public Text QuestText;

	// Use this for initialization
	void OnEnable () {
        int n = QuestLog.Progress;
        switch (n)
        {
            case 0:
                QuestText.text = "-Talk to the Mayor at the uppermost section of town." +
                    " He should be around the front of the church.";
                break;
            case 1:
                QuestText.text = "-Talk to the Class Trainer in the building to the right of the crossroads." +
                    " Pick a class and prepare to fight the monster.";
                break;
            case 2:
                QuestText.text = "-Exit the town to the left. Navigate the Forest until you reach the Forest Depths." +
                    " Find the monster there and slay it.";
                break;
            case 3:
                QuestText.text = "-Make your way back to the mayor. You'll have to go back through the maze to get back to town.";
                break;

            default:

                break;
        }
    }
	


}
