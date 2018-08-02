using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public GameObject Entrance;
    public GameObject Destination;
    public GameObject ExitDoor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destination.SetActive(true);
        collision.gameObject.transform.position = ExitDoor.transform.position;
        GameObject.Find("CurrentArea").GetComponent<Text>().text = Destination.name;
        Entrance.SetActive(false);
    }
}
