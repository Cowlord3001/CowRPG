using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOrder : MonoBehaviour {

    //public Transform [] Children;
    public List<GameObject> pages;
    int CurrentPage;
    int LastPage;

    public bool FirstEnter;

    bool FirstRead;
   

    // Use this for initialization
    void OnEnable () {
        if (LastPage == 0)
        {
            //Children = GetComponentsInChildren<Transform>();
            //foreach(Transform pg in Children)
            //{
            //    if(pg.gameObject.tag.StartsWith("Text"))
            //    {
            //        pages.Add(pg.gameObject);
            //    }
            //}
            LastPage = pages.Count;
            FirstRead = true;
            CurrentPage = 0;
        }
        else
        {
            CurrentPage = LastPage - 1;
        }

        if (FirstRead == true)
        {
            FirstEnter = true;
            pages[CurrentPage].SetActive(true);
            for (int i = 1; i < LastPage; i++)
            {
                pages[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < LastPage-1; i++)
            {
                pages[i].SetActive(false);
            }
            pages[LastPage-1].SetActive(true);
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
        if (CurrentPage == LastPage-1)
        {
            CloseDialogue();
        }
        else
        {
            CurrentPage = CurrentPage + 1;
            pages[CurrentPage].SetActive(true);
            pages[CurrentPage - 1].SetActive(false);
            
        }
    }

    public void CloseDialogue()
    {
        FirstRead = false;
        GameObject.Find("Player").GetComponent<NewMovement>().togglefreeze();
        gameObject.SetActive(false);
    }
}
