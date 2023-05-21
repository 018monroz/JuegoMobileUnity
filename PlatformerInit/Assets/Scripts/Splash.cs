using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    double init;
    double end;
    void Start()
    {
        init = Time.timeAsDouble;
    }

    // Update is called once per frame
    void Update()
    {
        end = Time.timeAsDouble;
        if(end-init > 30)
        {
            JumpScene();
        }
    }

    public void JumpScene()
    {
        SceneManager.CreateScene("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
