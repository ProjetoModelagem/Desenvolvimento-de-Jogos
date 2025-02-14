using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public float speed = 10.0f;             // Define a velocidade da raquete IA
    public float boundY = 2.25f;            // Limites em Y para a IA
    private Rigidbody2D rb2d;               // Corpo rígido 2D da IA

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa a IA
    }

    void Update()
    {
        // Obter a posição do mouse no mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ignorar a componente Z, já que estamos em 2D

        // Manter a posição da IA no eixo Y original, e seguir o mouse no eixo X
        float newX = mousePos.x;

        // Garantir que a posição Y da IA não ultrapasse os limites
        float newY = Mathf.Clamp(transform.position.y, -boundY, boundY);

        // Criar a nova posição com o eixo X do mouse e o Y limitado
        Vector3 newPos = new Vector3(newX, newY, transform.position.z);

        // Movimentar a IA de forma suave
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, newPos, step);
    }
}
