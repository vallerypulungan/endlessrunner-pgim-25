using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void Start()
    {
        // Menambahkan listener untuk mengaktifkan player saat game dimulai
        GameManager.instance.onPlay.AddListener(ActivatePlayer);
    }

    private void ActivatePlayer()
    {
        // Mengaktifkan GameObject player
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Mengecek apakah player bertabrakan dengan obstacle
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Menonaktifkan GameObject player dan memanggil GameOver
            gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }
    }
}
