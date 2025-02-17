using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement2 : MonoBehaviour
{
    private AudioSource audioSource;

    Rigidbody2D rb;
    Vector3 velocity;
    public Animator animator;
    Vector3 baslangicnoktasi;


    float speedAmount2 = 7f;
    float jumpAmount2 = 5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        baslangicnoktasi = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal2"), 0f);
        transform.position += velocity * speedAmount2 * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal2")));


        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.up * jumpAmount2, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }


        if (animator.GetBool("IsJumping") && Mathf.Approximately(rb.velocity.y, 0))
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetAxisRaw("Horizontal2") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal2") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            transform.position = baslangicnoktasi;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "finalZone")
        {
            SceneManager.LoadScene("player2winCountinue");
        }

        if (collision.gameObject.tag == "TrickArea1")
        {
            baslangicnoktasi = transform.position;
            SceneManager.LoadScene(5);
        }

        if (collision.gameObject.tag == "TrickArea2")
        {
            baslangicnoktasi = transform.position;
            SceneManager.LoadScene(6);
        }
    }
}
