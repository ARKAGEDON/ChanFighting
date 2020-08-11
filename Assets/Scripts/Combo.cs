using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Combo : MonoBehaviour
{
    private static Combo instance;
    public static Combo MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Combo>();
            }
            return instance;
        }
    }
    public int currentCombo;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI damageCombotxt;
    [SerializeField] private Info PlayerInfo;
    // Start is called before the first frame update
    void Start()
    {
        currentCombo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        damageCombotxt.text = (PlayerInfo.CurrentDamage * currentCombo).ToString();
        comboText.text = currentCombo.ToString() + " Hits";
    }
    public void AddCombo()
    {
        currentCombo ++;
    }
}
