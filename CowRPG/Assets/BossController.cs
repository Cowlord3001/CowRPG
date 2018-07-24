﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public GameObject[] Burst;
    public GameObject[] Line;
    public GameObject[] Border;
    public GameObject[] Beam;


    List<GameObject[]> Attacks;

    int AttackNum;
    float Timer;

    // Use this for initialization
    void Start () {
        Attacks = new List<GameObject[]>();


        Attacks.Add(Burst);
        Attacks.Add(Border);
        Attacks.Add(Beam);
        Debug.Log(Attacks.Count);
        Timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Timer = Timer + Time.deltaTime;
        if(Timer > 1)
        {
            RandomAttack();
            Timer = 0;
        }
	}

    void AttackOn(GameObject[] temp)
    {
        foreach (GameObject Attack in temp)
        {
            Attack.SetActive(true);
        }
    }

    void AttackOff(GameObject[] temp)
    {
        foreach (GameObject Attack in temp)
        {
            Attack.SetActive(false);
        }
    }

    void RandomAttack()
    {
        int x = Attacks.Count;

        int Rand = Random.Range(1, x + 1);

        Debug.Log(Rand + " Attacks On");

        List<GameObject[]> CurrentAttacks = new List<GameObject[]>();

        for (int i = 0; i < x; i++)
        {
            if( ((float)Rand/(float)x) > Random.Range(0, 1))
            {
                CurrentAttacks.Add(Attacks[i]);
                x--;
                Rand--;
            }
            else
            {
                x--;
            }
        }

        Debug.Log(CurrentAttacks.Count + " Attacks Selected");

        foreach (GameObject[] temp in Attacks)
        {
            AttackOff(temp);
        }

        foreach (GameObject[] temp in CurrentAttacks)
        {
            AttackOn(temp);
        }

    }
}
