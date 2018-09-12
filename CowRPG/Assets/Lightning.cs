using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    static int BranchNum;
    static int BranchDepth;
    public GameObject Bolt;

	// Use this for initialization
	void Start () {
		if(BranchNum == 0)
        {
            BranchNum = 3;
            BranchDepth = 100;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
