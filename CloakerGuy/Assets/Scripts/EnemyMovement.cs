using UnityEngine;

namespace HSS{

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public float speed = 2f;
    private int moveDirec;

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
        activeSpriteRenderer = spriteRendererDown;
        moveDirec = Random.Range(1,4);
    }

    void Start(){
        InvokeRepeating(nameof(ChangeMoveDirection), 3, 2);
    }

    void Update()
    {
        switch (moveDirec)
        {
            case 1:
                SetDirection(Vector2.up, spriteRendererUp);
                break;
            case 2:
                SetDirection(Vector2.down, spriteRendererDown);
                break;
            case 3:
                SetDirection(Vector2.left, spriteRendererLeft);
                break;
            case 4:
                SetDirection(Vector2.right, spriteRendererRight);
                break;
            default:
                SetDirection(Vector2.zero, activeSpriteRenderer);
                break;
        }

        
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            DeathSequence();
        }
    }


    private void DeathSequence()
    {
        enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
    }

    private void ChangeMoveDirection() {
            int temp = moveDirec;
            moveDirec = Random.Range(1, 5);

            if(moveDirec == temp)
                moveDirec++;

            if(moveDirec>4)
                moveDirec = 1;
    }

    }
}
