using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed = 70f;
    private bool isDestroyed = false; // Bandera para verificar si la nave ya ha sido destruida

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isDestroyed && other.CompareTag("Blast"))
        {
            isDestroyed = true; // Marcar la nave como destruida
            Destroy(other.gameObject); // Destruir el láser
            ScoreManager.instance.AddPoint(); // Añadir un punto al destruir algo
            Destroy(gameObject); // Destruir la nave enemiga
        }
        else if (other.CompareTag("Player"))
        {
            GameOverManager.instance.GameOver();
            Destroy(gameObject); // Destruir la nave enemiga
        }
        else if (other.CompareTag("Boundary"))
        {
            GameOverManager.instance.GameOver();
            Destroy(gameObject); // Destruir la nave enemiga
        }
    }
}

