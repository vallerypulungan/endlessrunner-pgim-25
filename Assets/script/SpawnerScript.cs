using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs; // Array prefab obstacle yang akan di-spawn
    public float spawnInterval = 10f; // Interval waktu antar spawn obstacle
    public float obstacleSpeed = 5f; // Kecepatan obstacle bergerak
    private float timeUntilNextSpawn; // Waktu tersisa hingga spawn berikutnya

    // Variabel untuk peningkatan kesulitan
    public float difficultyIncreaseInterval = 10f; // Interval waktu untuk meningkatkan kesulitan
    public float minSpawnInterval = 3f; // Interval spawn minimum
    public float maxObstacleSpeed = 100f; // Batas maksimum kecepatan obstacle
    private float difficultyTimer; // Timer untuk melacak waktu peningkatan kesulitan

    private void Update()
    {
        // Jalankan loop spawn dan tingkatkan kesulitan jika game sedang berlangsung
        if (GameManager.instance.isPlaying)
        {
            SpawnLoop(); // Loop untuk spawn obstacle
            IncreaseDifficulty(); // Tingkatkan kesulitan
        }
    }

    private void SpawnLoop()
    {
        timeUntilNextSpawn += Time.deltaTime; // Hitung waktu hingga spawn berikutnya
        if (timeUntilNextSpawn >= spawnInterval)
        {
            Spawn(); // Spawn obstacle baru
            timeUntilNextSpawn = 0f; // Reset timer spawn

            // Set spawn interval secara random antara 3f hingga 7f
            spawnInterval = Random.Range(3f, 7f);
        }
    }

    private void Spawn() 
    {
        // Pilih obstacle secara acak dari array prefab
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Spawn obstacle di posisi spawner
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        Rigidbody2D obstaclerb = spawnedObstacle.GetComponent<Rigidbody2D>(); // Ambil Rigidbody2D obstacle
        obstaclerb.linearVelocity = Vector2.left * obstacleSpeed; // Atur kecepatan obstacle
    }

    private void IncreaseDifficulty()
    {
        difficultyTimer += Time.deltaTime; // Tambahkan waktu ke timer kesulitan

        if (difficultyTimer >= difficultyIncreaseInterval)
        {
            difficultyTimer = 0f; // Reset timer kesulitan

            // Tingkatkan kecepatan obstacle
            obstacleSpeed += 0.5f;
        }
    }
}
