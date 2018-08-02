using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorld_Controller : MonoBehaviour
{

    public static GameObject OverWorld;
    public GameObject[] Arenas;

    // Use this for initialization
    void Start ()
    {
        OverWorld = GameObject.Find("OverWorld");

        foreach (GameObject Arena in Arenas)
        {
            Arena.SetActive(false);
        }
        
    }
}
