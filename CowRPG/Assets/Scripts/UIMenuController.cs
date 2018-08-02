using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuController : MonoBehaviour {

    public GameObject OptionsScreen, PlayerScreen, QuestScreen, ExitScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)&& 
        PlayerScreen.gameObject.activeSelf == false &&
        QuestScreen.gameObject.activeSelf == false &&
        ExitScreen.gameObject.activeSelf == false &&
        OptionsScreen.gameObject.activeSelf == false)
        {
            OptionsScreen.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerScreen.gameObject.SetActive(false);
            QuestScreen.gameObject.SetActive(false);
            ExitScreen.gameObject.SetActive(false);
            OptionsScreen.gameObject.SetActive(false);
        }
	}
    
    public void Button(string x)
    {
        if(x == "Player")
        {
            PlayerScreen.gameObject.SetActive(true);
            OptionsScreen.gameObject.SetActive(false);
        }

        if (x == "Quest")
        {
            QuestScreen.gameObject.SetActive(true);
            OptionsScreen.gameObject.SetActive(false);
        }

        if (x == "Exit")
        {
            ExitScreen.gameObject.SetActive(true);
            OptionsScreen.gameObject.SetActive(false);
        }

        if (x == "Options")
        {
            PlayerScreen.gameObject.SetActive(false);
            QuestScreen.gameObject.SetActive(false);
            ExitScreen.gameObject.SetActive(false);
            OptionsScreen.gameObject.SetActive(true);
        }
    }
}
