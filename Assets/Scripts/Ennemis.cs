using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentMana;
    [SerializeField] private float maxHealth;
    [SerializeField] private float MaxMana;
    [SerializeField] private float currentDamage;
    [Header("Death")]
    [SerializeField] private bool isDead = false;

    public float CurrentDamage { get => currentDamage; }
    public GameObject TPPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = 0;
        isDead = false;
        Collider _col = GetComponent<Collider>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        _col.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CmdApplyDamage(float TheDamage)
    {
        if (isDead)
        {
            return;
        }
        //Dégats normaux et affichés
        // la fameuse équation : PDV = PDV -(damage - ((armor * damage) / 100))
        currentHealth = (currentHealth - TheDamage);
        //Si la vie du joueur = 0 alors fonction
        if(currentHealth <= 0)
        {
            Dead();
        }
        Combo.MyInstance.AddCombo();
    }
    public void Dead() {
        // On désactive la possibilité de déplacer son personnage lorsqu'il meurt
        isDead = true;

        Collider _col = GetComponent<Collider>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        _col.isTrigger = true;

        Debug.Log(transform.name + " est mort.");
    }
}
