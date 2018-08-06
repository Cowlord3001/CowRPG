using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public GameObject[] Burst;
    public GameObject[] Line;
    public GameObject[] Border;
    public GameObject[] Beam;
    public GameObject[] Wheel;
    public GameObject[] BorderWheels;

    Chase MyMovement;
    EnemyHealth MyHealth;
    float AttackInterval;


    List<GameObject[]> Attacks;

    int AttackNum;
    float Timer;

    // Use this for initialization
    void Start () {
        MyMovement = GetComponent<Chase>();
        MyHealth = GetComponent<EnemyHealth>();
        AttackInterval = 12;
        Attacks = new List<GameObject[]>();


        Attacks.Add(Burst);
        Attacks.Add(Border);
        Attacks.Add(Beam);
        Attacks.Add(Line);
        Attacks.Add(Wheel);
        Timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(MyHealth.hp <= 1000)
        {
            if(AttackInterval == 12)
            {
                Attacks.Add(BorderWheels);
            }
            MyMovement.MaxSpeed = 1.5f;
            MyMovement.Damage = 8;
            AttackInterval = 10;
        }

        Timer = Timer + Time.deltaTime;
        if(Timer > AttackInterval)
        {
            RandomAttack();
            Timer = 0;
        }

        if(Chase.Dashing == true)
        {
            AttackOff(Beam);
            AttackOff(Burst);
            AttackOff(Border);
            AttackOff(Line);
            AttackOff(Wheel);
            AttackOff(BorderWheels);

            Timer = 5;
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

        int Rand = Random.Range(1, 4);

        //Debug.Log(Rand + " Attacks On");

        List<GameObject[]> CurrentAttacks = new List<GameObject[]>();

        for (int i = 0; i < Attacks.Count; i++)
        {
            if( ((float)Rand/(float)x) > Random.Range(0f, 1f))
            {
                //Debug.Log(i+1 + " Attack Selected");
                CurrentAttacks.Add(Attacks[i]);
                x--;
                Rand--;
            }
            else
            {
                x--;
            }
        }

        //Debug.Log(CurrentAttacks.Count + " Attacks Selected");

        foreach (GameObject[] temp in Attacks)
        {
            AttackOff(temp);
        }

        foreach (GameObject[] temp in CurrentAttacks)
        {
            AttackOn(temp);
        }

    }

    private void OnDestroy()
    {
        GameObject.Find("OverWorld Control").GetComponent<QuestLog>().Boss1Death();
    }
}
