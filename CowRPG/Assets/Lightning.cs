﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    static int BranchNum;
    static int BranchDepth;
    public GameObject Bolt;
    bool Damaging;
    bool Damaged;

	// Use this for initialization
	IEnumerator Start () {

        InvokeRepeating("Flashing", 0, .4f);

        if (BranchNum == 0)
        {
            BranchNum = 3;
            //3
            BranchDepth = 100;
            //100
            for (int i = 0; i < BranchNum; i++)
            {
                GameObject GO = Instantiate(Bolt, 
                            transform.position + (transform.right * .3f), 
                            transform.rotation * Quaternion.AngleAxis(-45 + 45 * i, Vector3.forward));
                GO.transform.position += .35f * GO.transform.right;

            }
        }
        else if(BranchDepth > 0)
        {

            yield return new WaitForSeconds(.05f);

            int temp = Random.Range(1, 3);
            BranchNum = temp;

            for (int i = 0; i < BranchNum; i++)
            {
                float temp2 = Random.Range(-1f, 1f);
                GameObject GO = Instantiate(Bolt,
                            transform.position + (transform.right * .3f),
                            transform.rotation * Quaternion.AngleAxis(temp2 * 45f, Vector3.forward));
                GO.transform.position += .35f * GO.transform.right;
            }
            BranchDepth--;
            
        }
        Destroy(gameObject, 4);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void Flashing()
    {
        if (Damaging == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7688679f, 0.9059389f, 1, 1);
            Damaging = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Damaging = true;
        }
        Damaged = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Damaging == true && collision.gameObject.tag == "Enemy" && Damaged == false)
        {
            collision.gameObject.SendMessage("ApplyDMG", 1);
            Damaged = true;
        }
    }

}
