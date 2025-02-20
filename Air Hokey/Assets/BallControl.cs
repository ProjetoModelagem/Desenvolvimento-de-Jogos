using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d; // Corpo rígido 2D da bola

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        Invoke("GoBall", 2); // Chama a função GoBall após 2 segundos
    }

    // Inicializa a bola aleatoriamente para a esquerda ou direita e para cima ou baixo
    void GoBall()
    {
        float randX = Random.Range(0, 2) == 0 ? -1 : 1; // Escolhe -1 ou 1 aleatoriamente
        float randY = Random.Range(0, 2) == 0 ? -1 : 1; // Escolhe -1 ou 1 aleatoriamente

        rb2d.velocity = new Vector2(5 * randX, 3 * randY); // Define a velocidade inicial da bola
    }

    // Determina o comportamento da bola nas colisões com os jogadores
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel; // Atualiza a velocidade da bola após a colisão
        }
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
}
