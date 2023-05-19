using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] GameObject PauseBtn;
    [SerializeField] GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toMainGame()
    {
        SceneManager.CreateScene("SampleScene");
        SceneManager.LoadScene("SampleScene");

    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        PauseBtn.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        PauseBtn.SetActive(true);
    }
}
