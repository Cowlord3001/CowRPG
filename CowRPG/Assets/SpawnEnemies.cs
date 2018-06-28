using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public float Height, Width;
    public GameObject[] Enemies;
    List<GameObject> DeadEnemies;
    public List<GameObject> ActiveEnemies;
    public int EnemyMax;
    public GameObject Overworld;
    GameObject Player;

	// Use this for initialization
	void OnEnable ()
    {
        int EnemyNum = Random.Range(1, EnemyMax);
        Player = GameObject.Find("APlayer");

        Player.transform.position = (Vector2)transform.position + new Vector2(-Width / 2, 0);
        Player.transform.GetChild(0).tag = QuestLog.Class;

        for (int i = 0; i < EnemyNum; i++)
        {
            int n = Random.Range(0, Enemies.Length);
            GameObject Enemy = Instantiate(Enemies[n],
                               transform.position + new Vector3(Width / 2, -Height / 2 + i),
                               Quaternion.identity);

            ActiveEnemies.Add(Enemy);
        }
        
	}
	
    void LoadWorld()
    {
        Overworld.gameObject.SetActive(true);
        Debug.Log("OverWorld Enabled by SpawnEnemies");
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void LateUpdate () {
		if(ActiveEnemies.Count == 0)
        {
            Invoke("LoadWorld", 2);
        }
        else
        {
            ActiveEnemies.RemoveAll(Enemy => Enemy == null);
        }
	}
}
