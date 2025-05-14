using UnityEngine;

public class TilemapLooper : MonoBehaviour
{
    [SerializeField] private float tileWidth = 5f; // Lebar satu tile
    [SerializeField] private float speedMultiplier = 0.5f; // Faktor pengali untuk kecepatan pergerakan
    private SpawnerScript spawner; // Referensi ke SpawnerScript
    private Vector3 startPosition; // Posisi awal tilemap

    private void Start()
    {
        // Simpan posisi awal
        startPosition = transform.position;

        // Cari SpawnerScript di scene
        spawner = FindObjectOfType<SpawnerScript>();
        if (spawner == null)
        {
            Debug.LogError("SpawnerScript tidak ditemukan di scene!");
        }
    }

    private void Update()
    {
        // Periksa apakah game sedang berlangsung
        if (GameManager.instance != null && GameManager.instance.isPlaying && spawner != null)
        {
            // Geser posisi tilemap berdasarkan kecepatan obstacle
            float adjustedSpeed = spawner.obstacleSpeed * speedMultiplier;
            transform.position += Vector3.left * adjustedSpeed * Time.deltaTime;

            // Looping: Jika tilemap melewati batas, kembalikan ke posisi awal
            if (transform.position.x <= startPosition.x - tileWidth)
            {
                transform.position += Vector3.right * tileWidth;
            }
        }
    }
}