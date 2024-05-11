using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            Vector3 vec = new Vector3(
                Input.GetAxisRaw("Horizontal") * Time.deltaTime,
                Input.GetAxisRaw("Vertical") * Time.deltaTime
            );

            transform.Translate(vec);
        }
    }
}
