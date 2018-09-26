using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int hp;
    public int lvl;
    public int EXP;
    public GameObject Death;
    TextMesh DisplayHP;
    int Total;
    float Timer;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < lvl; i++)
        {
            int x = Random.Range(10, 20);
            hp = hp + x;
            int y = Random.Range(2, 7);
            EXP = EXP + y;
        }

        DisplayHP = GetComponentInChildren<TextMesh>();

        
	}
	
	// Update is called once per frame
	void Update () {
        DisplayHP.text = hp.ToString();
        //Timer += Time.deltaTime;
        //if(Timer >= 5)
        //{
        //    Timer = 0;
        //    Total = 0;
        //}
	}

    void ApplyDMG(int DMG)
    {
        //Total += DMG;
        //if (Total < 200)
        //{
        //    hp = hp - DMG;
        //}
        hp -= DMG;
        if (hp <= 0)
        {
            GameObject GO = Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(GO, 2);
            QuestLog.AddEXP(EXP);
            if(gameObject.name == "ChaserMiniboss" || gameObject.name == "RangerMiniboss" || gameObject.name == "WarperMiniboss")
            {
                GameObject.Find("OverWorld Control").GetComponent<QuestLog>().MiniBossHelper();
                //QuestLog.ForestMinibossCounter();
            }
            Destroy(gameObject);
        }
        
    }
}
