using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class comboHits : MonoBehaviour
{
    Animator anim;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 1.2f;
    public bool IsAttack = false;
    private bool locked = false;
    [SerializeField] GameObject closest;
    List<GameObject> enemyLocations = new List<GameObject>();
    private Transform Tp;
    [Header("Bool de sorts")]
    //Activer les bools en fonctions des sorts de la chan
    [SerializeField] private bool Tpbool;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            lastClickedTime = Time.time;
            noOfClicks++;
            if (noOfClicks == 1)
            {
                StartCoroutine(PunchR());
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 2);
        }
        if (closest != null && locked)
        {
            closest.GetComponent<Locking>().Show();
        }
        if(Input.GetButtonDown("Lock")) 
        {
            if (locked == true)
            {
                closest.GetComponent<Locking>().Hide();
                locked = false;
                closest = null;
            }
            else
            {
                //Looks for the closest enemy
                FindClosestEnemy();
                locked = true;
            }
        }
        if(locked) 
        {
            //If there aren't any enemies (or the player killed the last one targeted) make sure that the lock is false
            if (!closest)
            {       
                closest.GetComponent<Locking>().Hide();
                locked = false;
                closest = null;
            }
            //if (Attack == true)
            transform.LookAt(new Vector3(closest.GetComponent<Locking>().lockingPoint.position.x, closest.GetComponent<Locking>().lockingPoint.position.y, closest.GetComponent<Locking>().lockingPoint.position.z));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Tpbool == true)
            {
            if (Info.MyInstance.CurrentMana >= 50)
            {
                FindClosestEnemy();
                if (closest.tag == "Ennemy")
                {
                    Tp = closest.GetComponent<Ennemis>().TPPoint.transform;
                }
                else if (closest.tag == "Joueur")
                {
                    Tp = closest.GetComponent<Info>().TPPoint.transform;
                }
                gameObject.transform.position = Tp.position;
                gameObject.GetComponent<Info>().RemoveMana(50);
            }
            }
        }
    }

    public void return1()
    {
        if (noOfClicks >= 2)
        {
            StartCoroutine(PunchL());
        }
        else
        {
            noOfClicks = 0;
        }
    }

    /*public void return2()
    {
        if (noOfClicks >= 3)
        {
            anim.SetBool("Attack3", true);
        }
        else
        {
            anim.SetBool("PunchL", false);
            noOfClicks = 0;
        }
    }*/

    public void return2()
    {
        noOfClicks = 0;
    }
    public IEnumerator PunchR()
    {
        IsAttack = true;
        anim.SetBool("Punch R", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Punch R", false);
        IsAttack = false;
    }
    public IEnumerator PunchL()
    {
        IsAttack = true;
        anim.SetBool("Punch L", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Punch L", false);
        IsAttack = false;
        noOfClicks = 0;
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Joueur");
        Players = GameObject.FindGameObjectsWithTag("Ennemy");
        foreach (GameObject go in Players)
        {
            if (!go.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                enemyLocations.Add(go);
            }
        }
        float distance = Mathf.Infinity;
        Transform PlayerTransform = gameObject.transform;
        foreach (GameObject go in enemyLocations)
        {
            Vector3 diff = (go.transform.position - gameObject.transform.position);
            float currDistance = diff.sqrMagnitude;
            if (currDistance < distance)
            {
                closest = go;
                distance = currDistance;
            }
        }
        return closest;
    }

}
