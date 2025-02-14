//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Player : MonoBehaviour
//{
//    public float speed = 3f;
//    private Animator anim;
//    private Rigidbody2D rb;
//    private bool isGrounded = true; // Tracks if the player is on the ground
//    public float JumpForce = 3;

//    private void Start()
//    {
//        anim = GetComponent<Animator>();
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        // Check for the Up Arrow key press and grounded state to trigger jump
//        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
//        {
//            Jump();
//        }
//    }

//    private void Jump()
//    {
//        rb.AddForce(Vector2.up * (JumpForce), ForceMode2D.Impulse);

//        // Set the Jumping animation to true and mark as not grounded
//        anim.SetBool("Jumping", true);
//        isGrounded = false;
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        // Reset the Jumping animation and set grounded state when the player lands
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            anim.SetBool("Jumping", false);
//            isGrounded = true;
//        }
//    }
//}


using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public Image bar;
    public Image HPbar;
    public int HP = 5;
    public int maxHP = 5;
    public float fillAmount = 0.25f;


    public int Determination;

    public TMP_Text scoreDisplay;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded = true; // Tracks if the player is on the ground
    private bool isJumping = false; // Tracks if the player is currently jumping
    public float minJumpForce = 3f; // Minimum jump force
    public float maxJumpForce = 10f; // Maximum jump force
    private float jumpHoldTime = 0f; // Tracks how long the key is held
    public float maxHoldTime = 0.5f; // Maximum time to hold for full jump power
    public float hitResetTime = 0.5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bar.fillAmount = 0f;
    }

    void Update()
    {
        UpdateHealthBar();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Check for the Up Arrow key press and grounded state to start jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isJumping = true;
            jumpHoldTime = 0f; // Reset the hold time
        }

        // While the key is held down, increment the timer
        if (Input.GetKey(KeyCode.UpArrow) && isJumping)
        {
            jumpHoldTime += Time.deltaTime;
        }

        // When the key is released, calculate and perform the jump
        if (Input.GetKeyUp(KeyCode.UpArrow) && isJumping)
        {
            float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, jumpHoldTime / maxHoldTime);
            PerformJump(jumpForce);
            isJumping = false; // Reset the jumping state
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Determination"))
        {
            Determination++;
            Debug.Log("Determination: " + Determination);
            scoreDisplay.text = "Determination: " + Determination.ToString();

        }

        if (collision.CompareTag("White_Bone") || collision.CompareTag("Monster"))
        {
            HP--;
            anim.SetBool("Hit", true);
            HPbar.fillAmount -= fillAmount;
            StartCoroutine(ResetHit());
        }
    }

    private IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(hitResetTime); // Wait for the specified time
        anim.SetBool("Hit", false); // Reset "Hit" animation state
    }

    void UpdateHealthBar()
    {

        if (HPbar.fillAmount <= 0)
        {
            HPbar.fillAmount = 0f;
            HP = 0;
            SceneManager.LoadScene("Main Menu");
            HP = 5;
            // Here is where you add your script for the full bar action- meaning when you release the bar something happens, your choice 

        }
    }

    private void PerformJump(float jumpForce)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Set the Jumping animation to true and mark as not grounded
        anim.SetBool("Jumping", true);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset the Jumping animation and set grounded state when the player lands
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("Jumping", false);
            isGrounded = true;
        }
    }
}

