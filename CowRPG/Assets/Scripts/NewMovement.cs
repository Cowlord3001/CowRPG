using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMovement : MonoBehaviour {

    public float Speed;
    float Stamina;
    public float MaxStam;
    bool Sprinting;
    float StaminaRechargeRate;
    public Slider StamBar;
    Rigidbody2D MyBody;
    bool freeze;

	// Use this for initialization
	void Start () {
        MyBody = GetComponent<Rigidbody2D>();
        freeze = false;
        Sprinting = false;
        StaminaRechargeRate = 1.5f;
        Stamina = MaxStam;
        StamBar.maxValue = MaxStam;
        StamBar.value = MaxStam;
    }

    public void freezeoff()
    {
        freeze = false;
    }

    public void freezeon()
    {
        freeze = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Sprinting == false && Stamina > 0)
        {
            Speed = Speed * 3;
            Sprinting = true;
            Image[] StamBarImages = StamBar.GetComponentsInChildren<Image>();
            StamBarImages[0].color = new Color(0, 0.4823f, 0.4705f, 1);
            StamBarImages[1].color = new Color(0, 1, 0.6274f, 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && Sprinting == true || Stamina <= 0 && Sprinting == true)
        {
            Speed = Speed/3;
            Sprinting = false;
            Image[] StamBarImages = StamBar.GetComponentsInChildren<Image>();
            StamBarImages[0].color = new Color(0, 0.4823f, 0.4705f, 0);
            StamBarImages[1].color = new Color(0, 1, 0.6274f, 0);
        }

        if(Sprinting == true && MyBody.velocity.magnitude > .01)
        {
            if(Stamina > 0)
            {
                Stamina = Stamina - Time.deltaTime;
            }
        }
        else
        {
            if(Stamina < MaxStam)
            {
                Stamina = Stamina + Time.deltaTime * StaminaRechargeRate;
            }
        }

        StamBar.value = Stamina;
        Walk();
    }

    void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }
        else
        {
            x = 0;
        }

        float y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.S))
        {
            y = -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            y = 1;
        }
        else
        {
            y = 0;
        }

        if (freeze == false)
        {
            if (x > 0 && y > 0)
            {
                MyBody.velocity = (Vector2.right + Vector2.up).normalized * Speed;
            }

            else if (x > 0 && y < 0)
            {
                MyBody.velocity = (Vector2.right + Vector2.down).normalized * Speed;
            }

            else if (x < 0 && y > 0)
            {
                MyBody.velocity = (Vector2.left + Vector2.up).normalized * Speed;
            }

            else if (x < 0 && y < 0)
            {
                MyBody.velocity = (Vector2.left + Vector2.down).normalized * Speed;
            }

            else if (x > 0)
            {
                MyBody.velocity = Vector2.right * Speed;
            }

            else if (x < 0)
            {
                MyBody.velocity = Vector2.left * Speed;
            }

            else if (y < 0)
            {
                MyBody.velocity = Vector2.down * Speed;
            }

            else if (y > 0)
            {
                MyBody.velocity = Vector2.up * Speed;
            }

            else
            {
                MyBody.velocity = Vector2.zero;
            }
        }
        else
        {
            MyBody.velocity = Vector2.zero;
        }
    }
}
