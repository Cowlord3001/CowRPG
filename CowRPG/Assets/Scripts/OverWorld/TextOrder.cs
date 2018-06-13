using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOrder : MonoBehaviour {

    public Transform [] Pages;
    int CurrentPage;
    int LastPage;

    public bool FirstEnter;

    bool FirstRead;


    // Use this for initialization
    void Start () {
        Pages = GetComponentsInChildren<Transform>();
        LastPage = Pages.Length - 1;
        CurrentPage = 3;
        Debug.Log(LastPage);
        FirstEnter = true;
        FirstRead = true;
        for (int i = 4; i <= LastPage; i++)
        {
            Pages[i].gameObject.SetActive(false);
        }
	}

    public void StartDialogue()
    {
        Pages = GetComponentsInChildren<Transform>();
        LastPage = Pages.Length - 1;
        CurrentPage = 3;
        Debug.Log(LastPage);
        FirstEnter = true;
        FirstRead = true;
        for (int i = 4; i <= LastPage; i++)
        {
            Pages[i].gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(FirstEnter == true)
            {
                FirstEnter = false;
            }
            else
            {
                OpenNextPage();
                FirstEnter = true;
            }

        }
	}

    void OpenNextPage()
    {
        if (CurrentPage == LastPage)
        {
            CloseDialogue();
        }
        else
        {
            CurrentPage = CurrentPage + 1;
            Pages[CurrentPage].gameObject.SetActive(true);
            Pages[CurrentPage - 1].gameObject.SetActive(false);
        }
    }

    public void CloseDialogue()
    {
        if(CurrentPage == LastPage)
        {
            FirstRead = false;
        }

        if(FirstRead == false)
        {
            gameObject.SetActive(false);
        }
        
    }
}
