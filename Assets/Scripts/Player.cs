using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int _lives = 5;
    public float Veloc;
    private float entradaHorizontal;
    private float entradaVertical;
    [SerializeField]
    private float JumpForce = 10.0f;
    public bool isGrounded;
    [SerializeField]
    private Rigidbody2D rig;
    // Start is called before the first frame update
   private void Start()
    {
        Veloc = 3.0f;
        transform.position = new Vector3(0, 0.0f, 0);
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   private void Update()
    {
        {
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                // Aplica uma força vertical para fazer o jogador saltar
                rig.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
                isGrounded = !isGrounded; // O jogador não está mais no chão após o salto
            }
        }
        Movimento();
    }
   public void Movimento()
    {
        entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Veloc * Time.deltaTime * entradaHorizontal);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
            if (collision.gameObject.CompareTag("Piso"))
            {
                isGrounded = true;  // O jogador está no chão
            }
            else 
            {
                isGrounded = false;
                StartCoroutine(UpTime());
            }
    }
    public IEnumerator UpTime()
    {
       yield return new WaitForSeconds(0.2f);
       isGrounded = true;
        
    }
}
