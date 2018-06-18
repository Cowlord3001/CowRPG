using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaWorld_Controller : MonoBehaviour {

    GameObject Arena;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        GameObject.Find("Arena");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
