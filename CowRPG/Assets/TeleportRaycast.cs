using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRaycast : MonoBehaviour {

    public float Min;
    public float Max;
    public int DirNum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector2 Teleport(float x, float y)
    {
        Vector2 dir = new Vector2(x, y);

        dir = dir - (Vector2)transform.position;
        Debug.DrawRay(transform.position, dir, Color.green, 800f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Max);

        if(Min > hit.collider.gameObject.transform.position.magnitude)
        {
            return Vector2.zero;
        }

       else if (hit.collider != null)
        {
            float Range;
            Range = Random.Range(Min, hit.collider.gameObject.transform.position.magnitude);
            Vector2 TargetPos = (Vector2)transform.position + dir.normalized * Range;
            return TargetPos;
        }

        else
        {
            float Range;
            Range = Random.Range(Min, Max);
            Vector2 TargetPos = (Vector2)transform.position + dir.normalized * Range;
            return TargetPos;
        }
    }

   public Vector2 RandomizedTP()
    {
        int i = Random.Range(1, DirNum);
        float x, y;
        x = Mathf.Cos(2 * Mathf.PI * i / DirNum);
        y = Mathf.Sin(2 * Mathf.PI * i / DirNum);

        return Teleport(x, y);

    }
}
