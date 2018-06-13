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
    void OnEnable () {
        if (LastPage == 0)
        {
            Pages = GetComponentsInChildren<Transform>();
            LastPage = Pages.Length;
            FirstRead = true;
            CurrentPage = 1;
        }
        else
        {
            CurrentPage = LastPage-2;
        }

        if (FirstRead == true)
        {
            FirstEnter = true;
            Pages[CurrentPage].gameObject.SetActive(true);
            for (int i = 2; i < LastPage; i++)
            {
                Pages[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 1; i < LastPage; i++)
            {
                Pages[i].gameObject.SetActive(false);
            }
            Pages[LastPage-1].gameObject.SetActive(true);
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
        if (CurrentPage == LastPage-2)
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
           FirstRead = false;
           gameObject.SetActive(false);
           GameObject.Find("Player").GetComponent<Movement>().togglefreeze();
    }
}
