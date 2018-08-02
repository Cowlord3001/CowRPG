using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour {

    public static GameObject Player;
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

    static int ForestMinibossCount;

	// Use this for initialization
	void Start () {
        Class = "Ranger";
        Progress = 0;
        EXP = 0;
        Level = 1;
        ForestMinibossCount = 0;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Class == "Ranger")
            {
                Class = "Fighter";
            }
            else if (Class == "Fighter")
            {
                Class = "Spellcaster";
            }
            else if (Class == "Spellcaster")
            {
                Class = "Ranger";
            }
            else if (Class == null)
            {
                Class = "Ranger";
            }
        }

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

    public void MiniBossHelper()
    {
        StartCoroutine(ForestMinibossCounter());
    }

    //void Idklol()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        ForestMinibossCount = 5;
    //        MiniBossHelper();
    //    }
    //}

    IEnumerator ForestMinibossCounter()
    {
        ForestMinibossCount++;
        //Debug.Log(ForestMinibossCount);
        if(ForestMinibossCount >= 3)
        {
            //Debug.Log("Function Run Waiting for 4 seconds");
            yield return new WaitForSeconds(4);

            //Debug.Log("Freeze the player in overworld and pan camera to wall");
            //Debug.Log("My Camera is " + Camera.main.gameObject.name);
            Player.GetComponent<NewMovement>().freezeon();
            GameObject GO = GameObject.Find("CamPoint");

            Vector3 Dir = GO.transform.position - Camera.main.transform.position;
            Dir = new Vector3(Dir.x, Dir.y, 0);

            float Timer = 0;

            while (Timer < 2)
            {
                Debug.Log("Moving Camera");
                Camera.main.transform.position = Camera.main.transform.position + Dir*(Time.deltaTime/2);
                Timer += Time.deltaTime;
                yield return null;
            }

            //Debug.Log("Wait for 2 seconds");
            yield return new WaitForSeconds(2);

            //Debug.Log("Delete Walls");
            GameObject.Find("Wall (93)").SetActive(false);
            GameObject.Find("Wall (94)").SetActive(false);
            yield return new WaitForSeconds(2);

            Dir = Player.transform.position - Camera.main.transform.position;
            Dir = new Vector3(Dir.x, Dir.y, 0);

            Timer = 0;

            while (Timer < 2)
            {
                Debug.Log("Moving Camera");
                Camera.main.transform.position = Camera.main.transform.position + Dir * (Time.deltaTime / 2);
                Timer += Time.deltaTime;
                yield return null;
            }
            
            Player.GetComponent<NewMovement>().freezeoff();
        }
    }

    int CameraMove(Vector2 Pos)
    {
        Camera.main.transform.position = Pos;

        return 1;
    }
}
