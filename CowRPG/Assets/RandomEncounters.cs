using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounters : MonoBehaviour {

    public GameObject Overworld;
    public GameObject[] Arenas;
    public float EncounterRate;

	// Use this for initialization
	void OnEnable () {
        InvokeRepeating("Encounter", 0, EncounterRate/2);
	}

    void OnDisable()
    {
        CancelInvoke();
    }

    // Update is called once per frame
    void Update () { 

	}

    void Encounter()
    {
        int Rand = Random.Range(0, 20);
        int RandAr = Random.Range(0, Arenas.Length);
        if(Rand < 10)
        {
            Arenas[RandAr].gameObject.SetActive(true);
            Overworld.gameObject.SetActive(false);
        }

    }
}
