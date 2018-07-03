using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public float Height, Width;
    public GameObject[] Enemies;
    List<GameObject> DeadEnemies;
    public List<GameObject> ActiveEnemies;
    public int EnemyMax;
    public int LvlMin, LvlMax;
    public GameObject Overworld;
    GameObject Player;

    bool loading;

	// Use this for initialization
	void OnEnable ()
    {
        loading = false;
        int EnemyNum = Random.Range(1, EnemyMax + 1);
        Player = GameObject.Find("APlayer");

        Player.transform.position = (Vector2)transform.GetChild(0).transform.position + new Vector2(-Width / 2, 0);
        Player.transform.GetChild(0).tag = QuestLog.Class;

        for (int i = 0; i < EnemyNum; i++)
        {
            int n = Random.Range(0, Enemies.Length);
            GameObject Enemy = Instantiate(Enemies[n],
                               transform.GetChild(0).transform.position + new Vector3(Width / 2, -Height / 2 + i * (Height / EnemyNum)),
                               Quaternion.identity);

            Enemy.GetComponent<EnemyHealth>().lvl = Random.Range(LvlMin, LvlMax + 1);

            ActiveEnemies.Add(Enemy);
        }
        
	}
	
    void LoadWorld()
    {
        Overworld.gameObject.SetActive(true);
        Debug.Log("OverWorld Enabled by SpawnEnemies ");
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void LateUpdate () {
		if(ActiveEnemies.Count == 0 && loading == false)
        {
            Invoke("LoadWorld", 2);
            loading = true;
        }
        else
        {
            ActiveEnemies.RemoveAll(Enemy => Enemy == null);
        }
	}
}
