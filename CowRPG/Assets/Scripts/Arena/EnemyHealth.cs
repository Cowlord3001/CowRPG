﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int hp;
    public int lvl;
    public int EXP;
    public GameObject Death;
    TextMesh DisplayHP;

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
	}

    void ApplyDMG(int DMG)
    {
        hp = hp - DMG;
        if (hp <= 0)
        {
            GameObject GO = Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(GO, 2);
            QuestLog.AddEXP(EXP);
            if(gameObject.name == "Miniboss 1" || gameObject.name == "Miniboss 2" || gameObject.name == "Miniboss 3")
            {
                QuestLog.ForestMinibossCounter();
            }
            Destroy(gameObject);
        }
        
    }
}
