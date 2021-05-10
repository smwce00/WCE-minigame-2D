using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move2D : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;

    public Text speedText;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        speedText.text = "Speed: " + Mathf.Abs(0).ToString();
    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        //Stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            speedText.text = "Speed: " + Mathf.Abs(0).ToString();
        }

        //Sprite direction 
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.5)
            anim.SetBool("isRunning", false);
        else { 
            anim.SetBool("isRunning", true);
            speedText.text = "Speed: " + Mathf.Abs(rigid.velocity.x).ToString();
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void FixedUpdate()
    {
        //move speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //max speed
        if (rigid.velocity.x > maxSpeed)
        {    //right Max speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            speedText.text = "Speed: " + Mathf.Abs(rigid.velocity.x).ToString();
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {    //left max speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            speedText.text = "Speed: " + Mathf.Abs(rigid.velocity.x).ToString();
        }

        //Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            speedText.text = "Speed: " + Mathf.Abs(0).ToString();

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.6f)
                    Debug.Log(rayHit.collider.name);
                anim.SetBool("isJumping", false);
            }
        }
    }
}
