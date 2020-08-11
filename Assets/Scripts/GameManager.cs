using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Players;
    [SerializeField] private bool Checked;
    List<GameObject> PlayerList = new List<GameObject>();
    [SerializeField] private bool win;
    // Start is called before the first frame update
    void Start()
    {
        Checked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Checked == false)
        {
            Players = GameObject.FindGameObjectsWithTag("Joueur");
            foreach (GameObject go in Players)
            {
                PlayerList.Add(go);
            }
            foreach (GameObject go in PlayerList)
            {
                go.GetComponent<Load>().StartLoading();
            }
            if (PlayerList.Count > 0)
            {
                Checked = true;
            }
        }
        foreach (GameObject go in PlayerList)
        {
            if (go.GetComponent<Info>().CurrentHealth < 0)
            {
                go.GetComponent<Info>().loose();
                PlayerList.Remove(go);
            }
        }
        if (win == true)
        {
            if (PlayerList.Count == 1)
            {
                foreach (GameObject go in PlayerList)
                {
                    go.GetComponent<Info>().win();
                }
            }
        }
    }
}
