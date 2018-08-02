using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounters : MonoBehaviour {

    public GameObject Overworld;
    public GameObject[] Arenas;
    public float EncounterRate;
    float Timestamp;

	// Use this for initialization
	void OnEnable () {
        //CancelInvoke("Encounter");
        //InvokeRepeating("Encounter", EncounterRate / 2, EncounterRate/2);
        Timestamp = 0;
    }

    void OnDisable()
    {
        //Debug.Log("Overworld Disabled by RandomEncounters");
        //CancelInvoke("Encounter");
    }

    // Update is called once per frame
    void Update () {
        if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > .01)
        {
            Timestamp = Timestamp + Time.deltaTime;
            if (Timestamp > EncounterRate/5)
            {
                Encounter();
                Timestamp = 0;
            }
        }
	}

    void Encounter()
    {
        int Rand = Random.Range(0, 20);
        int RandAr = Random.Range(0, Arenas.Length);
        Debug.Log("Chance for a Fight Triggered");
        if(Rand < 4)
        {
            Arenas[RandAr].gameObject.SetActive(true);
            Debug.Log("Arena Enabled by RandomEncounters");
            Overworld.gameObject.SetActive(false);
        }

    }
}
