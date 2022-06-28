using UnityEngine;
using System;

namespace HSS{
[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public static Action OnPlayerDeath;

    [Header("Audio Files")]
    private AudioSource sfxOutput;
    public AudioClip walkSound;


    [Header("Input")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sfxOutput = GetComponent<AudioSource>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        if (Input.GetKey(inputUp) || Input.GetKey(KeyCode.UpArrow)) {
            SetDirection(Vector2.up, spriteRendererUp);
                PlayWalking();
        } else if (Input.GetKey(inputDown)||Input.GetKey(KeyCode.DownArrow)) {
            SetDirection(Vector2.down, spriteRendererDown);
            PlayWalking();
        } else if (Input.GetKey(inputLeft) || Input.GetKey(KeyCode.LeftArrow)) {
            SetDirection(Vector2.left, spriteRendererLeft);
            PlayWalking();
        } else if (Input.GetKey(inputRight) || Input.GetKey(KeyCode.RightArrow)) {
            SetDirection(Vector2.right, spriteRendererRight);
            PlayWalking();
        } else {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }

        //if(Input.GetKeyDown(KeyCode.K))
           
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion")) {
                DeathSequence(activeSpriteRenderer);
        }
    }

    private void DeathSequence(AnimatedSpriteRenderer spriteRenderer)
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;
        spriteRendererDeath.enabled = spriteRenderer == spriteRendererDeath;
        activeSpriteRenderer = spriteRenderer;

        Invoke(nameof(OnDeathSequenceEnded), 3.25f);
    }

    private void OnDeathSequenceEnded()
    {
        OnPlayerDeath?.Invoke();
        gameObject.SetActive(false);
        
    }

        private void PlayWalking()
        {
            if (!sfxOutput.isPlaying)
            {
                sfxOutput.clip = walkSound;
                sfxOutput.Play();
            }
        }

}
}
