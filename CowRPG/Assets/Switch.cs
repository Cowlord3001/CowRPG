using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public GameObject[] Walls;
    public Sprite On;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = On;
        foreach (GameObject Wall in Walls)
        {
            Wall.SetActive(false);
        }
    }
}
