using UnityEngine;
using Mirror;

public class HideLocalPlayer : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            DisableComponents();
        }
    }

    private void DisableComponents()
    {
        // boucle pour désactiver les components des autres joueurs sur notre instance
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }
}
