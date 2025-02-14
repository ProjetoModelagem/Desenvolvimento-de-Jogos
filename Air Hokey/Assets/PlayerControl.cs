using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    
    public KeyCode moveUp = KeyCode.W;      // Move a raquete para cima
    public KeyCode moveDown = KeyCode.S;    // Move a raquete para baixo
    public float speed = 10.0f;             // Define a velocidade da bola
    public float boundY = 2.25f;            // Define os limites em Y
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete


    void Start () {
    rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
}


   void Update () {

    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    var pos = transform.position;
    pos.x = mousePos.x;
    pos.y = mousePos.y;
    transform.position = pos;

    var pos = transform.position;           // Acessa a Posição da raquete
    if (pos.y > boundY) {                  
        pos.y = boundY;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    else if (pos.y < -boundY) {
        pos.y = -boundY;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    if (pos.x > boundX){
        pos.x = boundX;
    }
    else if (pos.x < -boundX){
        pos.x = -boundX
    }
    transform.position = pos;               // Atualiza a posição da raquete

}



}
