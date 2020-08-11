using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    [System.Serializable]
    public class ChanManager : MonoBehaviour
    {
        public string ChanType;

        //This is a pseudo-function that must be called when we select a player and hit on "Continue". Basically what we do is to isolate the PlayerData gameObject instance from the SelectableCharacter
        //and later bound this to the Player controller that we will instantiate. It's not used in this project.
        public void PlayerSelected()
        {
            ChanManager PD = GameObject.FindWithTag("ChanManager").GetComponent<ChanManager>();
            if (ChanType == null)
            {
                PD.ChanType = "UnityChan";
            }
            else
            {
                PD.ChanType = ChanType;
            }
            DontDestroyOnLoad(PD);
            Debug.Log("Ajout de playerData");
        }
        public void ChooseCharacter(string characterName)
        {
            ChanType = characterName;
        }
        public void ChangeScene()
        {
            SceneManager.LoadScene("TrainingScene");
        }
    }