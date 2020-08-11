using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject Launch;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject VersusMenu;
    [SerializeField] private GameObject TrainingMenu;
    [SerializeField] private GameObject OptionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        Launch.SetActive(true);
        Menu.SetActive(false);
        VersusMenu.SetActive(false);
        TrainingMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Launch.SetActive(false);
            Menu.SetActive(true);
        }
        if (VersusMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            BackVersus();
        }
        if (TrainingMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            BackTraining();
        }
        if (OptionsMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            BackOptions();
        }
    }
    public void Versus()
    {
        VersusMenu.SetActive(true);
        Menu.SetActive(false);
    }
    public void Training()
    {
        TrainingMenu.SetActive(true);
        Menu.SetActive(false);
    }
    public void Options()
    {
        OptionsMenu.SetActive(true);
        Menu.SetActive(false);
    }
    public void BackVersus()
    {
        VersusMenu.SetActive(false);
        Menu.SetActive(true);
    }
    public void BackTraining()
    {
        TrainingMenu.SetActive(false);
        Menu.SetActive(true);
    }
    public void BackOptions()
    {
        OptionsMenu.SetActive(false);
        Menu.SetActive(true);
    }
    public void Leave()
    {
     #if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
    }
    public void TrainingPlay()
    {
        SceneManager.LoadScene("CharacterChoosingMenu");
    }
}
