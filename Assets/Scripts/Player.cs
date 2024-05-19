using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private CapsuleCollider2D col;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpPower;

    private bool isJump = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump
        if(Input.GetButtonDown("Jump") && isJump == false)
        {
            isJump = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        // Stop Speed
        if(Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // Direction Sprite
        if(Input.GetButtonDown("Horizontal"))
        {
            sprite.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
    }

    void FixedUpdate()
    {
        // Move By Key Control
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // 우측 최대 조건 
        if( rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        // 좌측 최대 조건
        else if(rigid.velocity.x < -maxSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
        }

        if(rigid.velocity.y < 0)
        {
            var rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if(rayHit.collider != null)
            {
                if(rayHit.distance < 0.5f)
                {
                    isJump = false;
                }
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {  
            Debug.Log("PlayerHit");
            OnDamage(collision.transform.position);
        }
    }

    private void OnDamage(Vector2 targetPos)
    {
        gameObject.layer = 9;

        sprite.color = new Color(1, 1, 1, 0.4f);

        var dirc = transform.position.x - targetPos.x > 0 ? 1:-1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        Invoke("OffDamaged", 3);
    }

    private void OffDamaged()
    {
        gameObject.layer = 6;

        sprite.color = new Color(1, 1, 1, 1);
    }
}
 