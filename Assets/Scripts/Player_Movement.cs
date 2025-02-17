using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    private AudioSource audioSource;
    public bool IsDead = false;

    Rigidbody2D rgb;

    Vector3 velocity;
    Vector3 baslangicnoktasi;

    public Animator animator;

    float speedAmount = 7f;
    float jumpAmount = 5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent < AudioSource >();
        baslangicnoktasi = transform.position;
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump"))
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }

        if (animator.GetBool("IsJumping") && Mathf.Approximately(rgb.velocity.y, 0)) 
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DeathArea")
        {
            transform.position = baslangicnoktasi;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "finalZone")
        {
            SceneManager.LoadScene(2);
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
