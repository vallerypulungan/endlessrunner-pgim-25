using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 8f; 
    [SerializeField] private Transform feetPos; 
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float moveSpeed = 5f; 
    [SerializeField] private Animator animator; // Animator untuk mengontrol animasi
    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private Vector3 initialPosition; // Posisi awal player

    private void Start()
    {
        initialPosition = transform.position; // Simpan posisi awal
        GameManager.instance.onPlay.AddListener(ResetPlayer); // Tambahkan listener untuk reset posisi
    }

    private void Update()
    {
        // Cek apakah player menyentuh tanah
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        // Ambil input horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Membatasi posisi player agar tetap berada di dalam layar
        Vector3 playerPosition = Camera.main.WorldToViewportPoint(transform.position);
        playerPosition.x = Mathf.Clamp(playerPosition.x, 0f, 1f); // Batas horizontal
        playerPosition.y = Mathf.Clamp(playerPosition.y, 0f, 1f); // Batas vertikal
        transform.position = Camera.main.ViewportToWorldPoint(playerPosition);

        // Membalik arah player berdasarkan arah gerakan
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Menghadap kanan (normal)
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Menghadap kiri (flip)
        }

        // Atur parameter animasi
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x)); // Kecepatan horizontal
        animator.SetFloat("yVelocity", rb.linearVelocity.y); // Kecepatan vertikal
        animator.SetBool("isJumping", !isGrounded); // Status lompat

        // Lompat
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        // Kontrol durasi lompat
        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }
    }

    private void ResetPlayer()
    {
        // Reset posisi player ke posisi awal
        transform.position = initialPosition;
        rb.linearVelocity = Vector2.zero; // Hentikan semua gerakan
    }
}


