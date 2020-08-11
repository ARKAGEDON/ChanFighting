using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoadTraining : MonoBehaviour
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
        
        StartCoroutine(Loading());
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
        // boucle pour désactiver les components des autres joueurs sur notre instance
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = true;
        }
        gameObject.GetComponent<Info>().StartRegenMana();
    }
}
