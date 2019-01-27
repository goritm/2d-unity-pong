using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject ballPrefab;
    private Ball currentBall;
    public Text score1Text;
    private int score1 = 0;
    public Text score2Text;
    private int score2 = 0;
    public int cantidadPuntos = 3;
    public Text ganadorText;
    public Text restartText;
    private bool restart = false;
    public float scoreCoordinates = 3.4f;

    // Use this for initialization
    void Start()
    {
        SpawnBall();
    }

    void SpawnBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab, transform);

        currentBall = ballInstance.GetComponent<Ball>();
        currentBall.transform.position = Vector2.zero;

        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBall != null)
        {
            if (currentBall.transform.position.x > scoreCoordinates)
            {
                score1++;
                Destroy(currentBall.gameObject);
                SpawnBall();
            }
            if (currentBall.transform.position.x < -scoreCoordinates)
            {
                score2++;
                Destroy(currentBall.gameObject);
                SpawnBall();
            }
        }

        if (score1 == cantidadPuntos)
        {
            ganadorText.color = Color.red;
            ganadorText.text = "¡GANA EL JUGADOR 1!";
            Destroy(currentBall);
            restart = true;
        }
        else if (score2 == cantidadPuntos)
        {
            ganadorText.color = Color.blue;
            ganadorText.text = "¡GANA EL JUGADOR 2!";
            Destroy(currentBall);
            restart = true;
        }

        if (restart)
        {
            restartText.color = Color.yellow;
            restartText.text = "Presione R para Reiniciar";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Juego", LoadSceneMode.Single);
            }
        }
    }
}
