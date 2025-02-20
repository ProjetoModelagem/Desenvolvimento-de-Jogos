using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;      // Move a raquete para cima
    public KeyCode moveDown = KeyCode.S;    // Move a raquete para baixo
    public float speed = 10.0f;             // Velocidade da raquete
    public float boundY = 4.5f;             // Define o limite superior em Y
    public float boundX = 11f;              // Define os limites em X
    private Rigidbody2D rb2d;               // Corpo rígido 2D da raquete

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa a raquete
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Garante que o eixo Z não seja alterado

        Vector2 newPosition = new Vector2(mousePos.x, mousePos.y);

        // Restringe dentro dos limites
        newPosition.x = Mathf.Clamp(newPosition.x, -boundX, boundX);
        newPosition.y = Mathf.Clamp(newPosition.y, 1, boundY); // Não pode descer abaixo de Y = 0

        // Movimenta a raquete suavemente usando Rigidbody2D
        rb2d.MovePosition(newPosition);
    }
}
