using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Info : MonoBehaviour
{
    private static Info instance;
    public static Info MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Info>();
            }
            return instance;
        }
    }
    [Header("UI")]
    [SerializeField] private Image healthImage;
    [SerializeField] private Image manaImage;
    [Header("Stats")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentMana;
    [SerializeField] private float maxHealth;
    [SerializeField] private float MaxMana;
    [SerializeField] private float currentDamage;
    [Header("Death")]
    [SerializeField] private Animator anim;
    [SerializeField] private bool isDead = false;

    public float CurrentDamage { get => currentDamage; }
    public float CurrentMana { get => currentMana; set => currentMana = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    [Header("Spell")]
    public GameObject TPPoint;
    [Header("Win or loose")]
    [SerializeField] private TextMeshProUGUI WLtext;
    [SerializeField] private GameObject BackMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
        CurrentMana = 0;
        isDead = false;
        anim.SetBool("Dead",false);
        Collider _col = GetComponent<Collider>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        _col.isTrigger = false;
        BackMenuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float percentageHP = ((CurrentHealth * 100) / maxHealth) / 100;
        healthImage.fillAmount = percentageHP;
        float percentageMANA = ((CurrentMana * 100) / MaxMana) / 100;
        manaImage.fillAmount = percentageMANA;
    }
    public void CmdApplyDamage(float TheDamage)
    {
        if (isDead)
        {
            return;
        }
        //Dégats normaux et affichés
        // la fameuse équation : PDV = PDV -(damage - ((armor * damage) / 100))
        CurrentHealth = (CurrentHealth - TheDamage);
        CurrentMana += (TheDamage /10);
        if (CurrentMana > MaxMana)
        {
            CurrentMana = MaxMana;
        }
        Debug.LogFormat("Ajout de mana par dégats subis {0}",CurrentMana);
        //Si la vie du joueur = 0 alors fonction
        if(CurrentHealth <= 0)
        {
            Dead();
        }
    }
    public void Dead() {
        // On désactive la possibilité de déplacer son personnage lorsqu'il meurt
        isDead = true;
        anim.SetBool("Dead",true);

        Collider _col = GetComponent<Collider>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        _col.isTrigger = true;

        Debug.Log(transform.name + " est mort.");
    }
    public IEnumerator RegenMana()
    {
        while (CurrentHealth > 0)
        {
            yield return new WaitForSeconds(1f);
            CurrentMana += 10;
            if (CurrentMana > MaxMana)
            {
                CurrentMana = MaxMana;
            }
            Debug.LogFormat("Ajout de mana par regen {0}",CurrentMana);
        }
    }
    public void AddMana(float Damage)
    {
        CurrentMana += Damage/10;
        if (CurrentMana > MaxMana)
        {
            CurrentMana = MaxMana;
        }
        Debug.LogFormat("Ajout de mana par dégats infligés {0}",CurrentMana);
    }
    public void RemoveMana(float removed)
    {
        currentMana -= removed;
        if (currentMana < 0)
        {
            CurrentMana = 0;
        }
    }
    public void StartRegenMana()
    {
        StartCoroutine(RegenMana());
    }
    public void loose()
    {
        Debug.Log("Loose");
        WLtext.text = "DEFAITE!";
        BackMenuButton.SetActive(true);
        Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
        gameObject.GetComponent<Load>().DisableComponents();
    }
    public void win()
    {
        Debug.Log("Win");
        WLtext.text = "VICTOIRE!";
        BackMenuButton.SetActive(true);
        Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
        gameObject.GetComponent<Load>().DisableComponents();
    }
    public void Disconnect()
    {
        GameObject Network = GameObject.FindGameObjectWithTag("NetworkManager");
        Network.GetComponent<NetworkManagerLobbyChan>().DisconnectFromServer();
    }
}
