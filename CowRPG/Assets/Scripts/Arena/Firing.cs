using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour {

    public GameObject RangedBullet;
    public GameObject RangedBullet2;
    public GameObject RangedBulletSpecial_Burst;
    public GameObject MeleeBullet;
    public GameObject[] SpellBullet;
    public GameObject SpellBulletSpecial_Bolt;
    public float ROF;
    float Timestamp;
    float Timer;
    bool Charging;
    GameObject GO;
    Vector3 Scale;
    int SpellType;

	// Use this for initialization
	void Start () {
        Timer = 11;
        SpellType = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.tag == "Ranger")
        {
            RangerFire();
        }
        else if(gameObject.tag == "Fighter")
        {
            FighterFire();
        }
        else if(gameObject.tag == "Spellcaster")
        {
            SpellFire();
        }

        Timer += Time.deltaTime;
	}

    void RangerFire()
    {
        //Debug.Log(((int)(100 /Time.deltaTime))/100);


        if(QuestLog.Level < 3)
        {
            if (Input.GetKey(KeyCode.Mouse0) && Timestamp + ROF < Time.time)
            {
                Instantiate(RangedBullet, transform.position, transform.parent.transform.rotation);
                Timestamp = Time.time;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && Timestamp + ROF*0.66 < Time.time)
            {
                Instantiate(RangedBullet2, transform.position, transform.parent.transform.rotation);
                Timestamp = Time.time;
            }
        }

        if (QuestLog.Level >= 5 && Input.GetKeyDown(KeyCode.Alpha1) && Timer > 10) 
        {
            RangerSpecial_Burst();
            Timer = 0;
        }
        
    }

    void FighterFire()
    {
        if (QuestLog.Level < 3)
        {
            if (Input.GetKey(KeyCode.Mouse0) && Timestamp + ROF * 4 < Time.time)
            {
                Instantiate(MeleeBullet, transform.position, transform.parent.transform.rotation);
                Timestamp = Time.time;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && Timestamp + ROF * 12 < Time.time)
            {
                int BulletNum = Random.Range(3, 9);
                for (int i = 0; i < BulletNum; i++)
                {
                    float Angle = Random.Range(-20, 20);
                    float Speed = MeleeBullet.GetComponent<Bullet>().Speed * Random.Range(.5f, 2);
                    float Lifetime = MeleeBullet.GetComponent<Bullet>().BulletLife * Random.Range(.1f, .3f);
                    Vector3 Scale = MeleeBullet.transform.localScale * Random.Range(.75f, 1.5f);

                    GameObject GO = Instantiate(MeleeBullet, transform.position,
                                transform.rotation * Quaternion.AngleAxis(Angle, Vector3.forward));
                    GO.GetComponent<Bullet>().Damage = Scale.x * 4;
                    GO.GetComponent<Bullet>().Death.transform.localScale = Scale;
                    GO.transform.localScale = Scale;
                    GO.GetComponent<Bullet>().BulletLife = Lifetime;
                    GO.GetComponent<Bullet>().Speed = Speed;
                }
                Timestamp = Time.time;
            }
        }
    }

    void SpellFire()
    {
        if (Input.GetKeyDown(KeyCode.Q) && QuestLog.Level >= 5)
        {
            SpellType++;
            SpellType = SpellType % 3;
            if (SpellType == 0)
            {
                GetComponent<SpriteRenderer>().color = Color.black;
            }
            else if (SpellType == 1)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (SpellType == 2)
            {
                GetComponent<SpriteRenderer>().color = new Color(0.7450981f, 0, 1, 1);
            }
            else
            {
                
            }
        }

        if (GO == null)
        {
            Charging = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Timestamp + ROF * 10 < Time.time)
        {
            GO = Instantiate(SpellBullet[SpellType], transform.position, transform.parent.transform.rotation);
            Timestamp = Time.time;
            Charging = true;
            Scale = GO.transform.localScale;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0) && GO != null)
        {
            GO.GetComponent<Bullet>().Released = true;
            GO.GetComponent<Rigidbody2D>().velocity = transform.right * 5;
            GO = null;
            Charging = false;
            
        }
        if(Charging == true)
        {
            GO.transform.position = transform.position + transform.right;
            GO.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
            if (GO.transform.localScale.x < 5)
            {
                GO.transform.localScale = GO.transform.localScale + Scale * Time.deltaTime * .5f;
                ParticleSystem.MainModule main;
                main = GO.GetComponent<Bullet>().Death.GetComponent<ParticleSystem>().main;
                main.startSize = GO.transform.localScale.x * .06f;
                GO.GetComponent<Bullet>().Damage = 3 + (150 / 8) * (Time.time - Timestamp);
            }
        }
        if (QuestLog.Level >= 5 && Input.GetKeyDown(KeyCode.Alpha1) && Timer > 10)
        {
            SpellcasterSpecial_Bolt();
            Timer = 0;
        }
    }

    void RangerSpecial_Burst()
    {
        ROF += 100000;

        float angle = 45 / 5;
        for (int i = -5 / 2; i <= 5 / 2; i++)
        {
            Instantiate(RangedBulletSpecial_Burst, 
                        transform.position, 
                        transform.rotation * Quaternion.AngleAxis((angle * i) + angle / 2, Vector3.forward));
        }

        ROF -= 100000;
    }

    void SpellcasterSpecial_Bolt()
    {
        ROF += 100000;
        Lightning.Killswitch();
        Instantiate(SpellBulletSpecial_Bolt,
                    transform.position,
                    transform.rotation);
        ROF -= 100000;
    }

}
