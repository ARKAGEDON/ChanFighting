using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;
public class Load : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI LoadCounter;
    [SerializeField] Behaviour[] componentsToDisable;
    [SerializeField] private int LoadCount;
    private void Start() {
        LoadCounter.text = "";
        DisableComponents();
    }
    public void StartLoading()
    {
        
        if (isLocalPlayer){
        Debug.Log("Start Loading fonction called");
        StartCoroutine(Loading());
        }
    }
    public IEnumerator Loading()
    {
        LoadCount = 4;
        while (LoadCount > 0)
        {
            LoadCount --;
            LoadCounter.text = LoadCount.ToString();
            yield return new WaitForSeconds(1f);
        }
        if (LoadCount <= 0)
        {
            LoadCounter.text = "GO";
            EnableComponents();
            yield return new WaitForSeconds(1f);
            LoadCounter.text = "";
        }

    }
    public void DisableComponents()
    {
        // boucle pour désactiver les components des autres joueurs sur notre instance
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }
    public void EnableComponents()
    {
        if (isLocalPlayer){
        // boucle pour désactiver les components des autres joueurs sur notre instance
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = true;
        }
        gameObject.GetComponent<Info>().StartRegenMana();
        }
    }
}
