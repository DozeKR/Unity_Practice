using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private CapsuleCollider2D col;
    [SerializeField] private int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<CapsuleCollider2D>();
        
        Invoke("EnemyAI", 5);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector3(nextMove, rigid.velocity.y);

        var frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        var rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if(rayHit.collider == null)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke("EnemyAI", 5);
        }
    }

    private void EnemyAI()
    {
        nextMove = Random.Range(-1, 2);

        var randomTime = Random.Range(2f, 5f);
        Invoke("EnemyAI", randomTime);
    }


    public void OnDamaged()
    {
        sprite.color = new Color(1, 1, 1, 0.4f);

        sprite.flipY = true;

        col.enabled = false;

        rigid. AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        Invoke("DeActive", 3);
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

}
