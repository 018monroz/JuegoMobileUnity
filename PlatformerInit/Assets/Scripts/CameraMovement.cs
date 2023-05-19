using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerPosition;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;
    float maxYPos;
    float puntuacion = 0;
    float puntuacionMaxima = 0;
    void Start()
    {
        maxYPos = playerPosition.position.y;
        //Guardado en localstorage
        if (PlayerPrefs.HasKey("highscore")) puntuacionMaxima = PlayerPrefs.GetFloat("highscore");
        highscoreText.text = $"HighScore:\n{(int)puntuacionMaxima}";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition.position.y > maxYPos)
        {
            maxYPos = playerPosition.position.y;
            puntuacion += 10 * Time.deltaTime;
            scoreText.text = $"Score:\n{(int)puntuacion}";
            highscoreText.text = $"HighScore:\n{(int)puntuacionMaxima}";
            if (puntuacionMaxima < puntuacion) puntuacionMaxima = puntuacion;
            PlayerPrefs.SetFloat("highscore", puntuacionMaxima);
        }
        Vector3 cameraPos = new Vector3(0,maxYPos,-10);
        transform.position = cameraPos;
        
    }
}
