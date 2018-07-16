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

        Debug.DrawRay(transform.position, dir, Color.green, 800f);
        RaycastHit2D hit = Physics2D.Raycast((Vector2) transform.position+Min*dir, (Vector2)transform.position + dir*Max, Max);

        if(hit.collider == null)
        {
            float Range;
            Range = Random.Range(Min, Max);
            Vector2 TargetPos = (Vector2)transform.position + dir * Range;
            return TargetPos;
        }
        else if(Min > hit.collider.gameObject.transform.position.magnitude)
        {
            return transform.position;
        }
        else
        {
            float Range;
            Range = Random.Range(Min, (hit.collider.gameObject.transform.position - transform.position).magnitude - 1);
            Vector2 TargetPos = (Vector2)transform.position + dir * Range;
            return TargetPos;
        }
        
    }

   public Vector2 RandomizedTP()
    {
        int i = Random.Range(1, DirNum+1);
        float x, y;

        x = Mathf.Cos(2 * Mathf.PI * i / DirNum);
        y = Mathf.Sin(2 * Mathf.PI * i / DirNum);
        

        return Teleport(x, y);

    }
}
