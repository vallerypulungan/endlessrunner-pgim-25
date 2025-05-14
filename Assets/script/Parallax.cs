using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer; // Komponen MeshRenderer untuk mengakses material
    public float speedMultiplier = 0.002f; // Faktor pengali untuk memperlambat kecepatan parallax
    private SpawnerScript spawner; // Referensi ke SpawnerScript untuk mendapatkan kecepatan obstacle

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); // Ambil komponen MeshRenderer dari GameObject
    }

    private void Start()
    {
        spawner = FindObjectOfType<SpawnerScript>(); // Cari SpawnerScript di scene
        if (spawner == null)
        {
            Debug.LogError("SpawnerScript tidak ditemukan di scene!"); // Tampilkan error jika SpawnerScript tidak ditemukan
        }
    }

    private void Update()
    {
        // Periksa apakah game sedang berlangsung dan SpawnerScript tersedia
        if (GameManager.instance != null && GameManager.instance.isPlaying && spawner != null)
        {
            // Hitung kecepatan parallax berdasarkan kecepatan obstacle
            float adjustedSpeed = spawner.obstacleSpeed * speedMultiplier;
            // Geser offset tekstur material untuk menciptakan efek parallax
            meshRenderer.material.mainTextureOffset += new Vector2(adjustedSpeed * Time.deltaTime, 0f);
        }
    }
}