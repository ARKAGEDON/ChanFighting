using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    //Récupérer Gameobjet du parent
    [SerializeField] private GameObject Parent;
    private bool isColliding = false;
    //On vérifie si les détecteurs ont touchés quelqu'un ou quelque chose
    void OnTriggerEnter(Collider other)
    {
        if(isColliding) return;
        isColliding = true;
        //Si le tag de l'objet touché est Ennemy alors c'est un joueur qui tape et on applique les dégats du joueur.
        if(other.tag == "Ennemy")
        {
			if (Parent.GetComponent<comboHits>().IsAttack == true)
			{
                Parent.GetComponent<comboHits>().IsAttack = false;
				other.GetComponent<Ennemis>().CmdApplyDamage(Parent.GetComponent<Info>().CurrentDamage);
                Parent.GetComponent<Info>().AddMana(Parent.GetComponent<Info>().CurrentDamage);
			}
        }
        //Si le tag de l'objet touché est Joueur alors c'est un ennemis qui tape et on applique les dégats du joueur mais avant vérification de quelle ennemis au cas où ajout de différent script pour les ennemis.
        if(other.tag == "Joueur")
        {
			if (Parent.GetComponent<comboHits>().IsAttack == true)
			{
                Parent.GetComponent<comboHits>().IsAttack = false;
				other.GetComponent<Info>().CmdApplyDamage(Parent.GetComponent<Info>().CurrentDamage);
                Parent.GetComponent<Info>().AddMana(Parent.GetComponent<Info>().CurrentDamage);
			}
        }
        StartCoroutine(Reset());

    }
    void OnTriggerStay(Collider other)
    {
        if(isColliding) return;
        isColliding = true;
        //Si le tag de l'objet touché est Ennemy alors c'est un joueur qui tape et on applique les dégats du joueur.
        if(other.tag == "Ennemy")
        {
			if (Parent.GetComponent<comboHits>().IsAttack == true)
			{
                Parent.GetComponent<comboHits>().IsAttack = false;
				other.GetComponent<Ennemis>().CmdApplyDamage(Parent.GetComponent<Info>().CurrentDamage);
                Parent.GetComponent<Info>().AddMana(Parent.GetComponent<Info>().CurrentDamage);
			}
        }
        //Si le tag de l'objet touché est Joueur alors c'est un ennemis qui tape et on applique les dégats du joueur mais avant vérification de quelle ennemis au cas où ajout de différent script pour les ennemis.
        if(other.tag == "Joueur")
        {
			if (Parent.GetComponent<comboHits>().IsAttack == true)
			{
                Parent.GetComponent<comboHits>().IsAttack = false;
				other.GetComponent<Info>().CmdApplyDamage(Parent.GetComponent<Info>().CurrentDamage);
                Parent.GetComponent<Info>().AddMana(Parent.GetComponent<Info>().CurrentDamage);
			}
        }
        StartCoroutine(Reset());

    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        isColliding = false;
    }
}
