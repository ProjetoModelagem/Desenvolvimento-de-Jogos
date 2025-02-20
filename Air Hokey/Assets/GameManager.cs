using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do Player 1
    public static int PlayerScore2 = 0; // Pontuação do Player 2

    public GUISkin layout;              // Fonte do placar
    private GameObject theBall;         // Referência ao objeto bola

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Bola"); // Busca a referência da bola
    }

    // Incrementa a pontuação   
    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }

    // Gerenciamento da pontuação e fluxo do jogo
    void OnGUI()
    {
        GUI.skin = layout;
        
        // Exibição do placar
        GUI.Label(new Rect(Screen.width / 2 - 162, 20, 100, 100), PlayerScore1.ToString());
        GUI.Label(new Rect(Screen.width / 2 + 162, 20, 100, 100), PlayerScore2.ToString());

        // Botão de reiniciar jogo
        if (GUI.Button(new Rect(Screen.width / 2 - 35, 20, 65, 25), "RESTART"))
        {
            RestartGame();
        }

        // Verificação de vitória
        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS!");
            theBall.SendMessage("ResetBall", SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS!");
            theBall.SendMessage("ResetBall", SendMessageOptions.RequireReceiver);
        }
    }

    // Reinicia o jogo
    private void RestartGame()
    {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        theBall.SendMessage("RestartGame", SendMessageOptions.RequireReceiver);
    }
}
