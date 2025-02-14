
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class Player2 : MonoBehaviour
{
    public float speed = 3f;
    public Image bar;
    public Image HPbar;
    public int HP = 5;
    public int maxHP = 5;
    public int maxSouls = 4;
    public float fillAmount = 0.25f;
    public Image Bravery;
    public Image Integrity;
    public Image Justice;
    public Image Kindness;
    public Image Perseverance;


    public int All_Souls;

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
        UpdatePowerBar();
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
        if (collision.CompareTag("Rainbow"))
        {
            Image[] soulImages = { Bravery, Integrity, Justice, Kindness, Perseverance };

            for (int i = 0; i < soulImages.Length; i++)
            {
                if (!soulImages[i].enabled)
                {
                    soulImages[i].enabled = true;
                    All_Souls++;
                    Debug.Log("All Souls: " + All_Souls);
                    UpdatePowerBar();
                    break; 
                }
            }

            // Check if all souls are collected
            if (soulImages.All(img => img.enabled))
            {
                // All souls are collected, you can add additional logic here
                Debug.Log("All souls collected!");
            }
        }


        if (collision.CompareTag("Blue_Bone") || collision.CompareTag("Monster"))
        {
            anim.SetBool("Hit", true);
            HP--;
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

    void UpdatePowerBar()
    {

        if (All_Souls >= maxSouls && Input.GetKeyDown(KeyCode.Q))
        {
            bar.fillAmount = 0f;
            All_Souls = 0;

            Image[] soulImages = { Bravery, Integrity, Justice, Kindness, Perseverance };
            foreach (var img in soulImages)
            {
                img.enabled = false;
            }

            ClearScene();
            Debug.Log("Power Bar released!");

            // Here is where you add your script for the full bar action- meaning when you release the bar something happens, your choice 

        }
    }

    private void ClearScene()
    {
        string[] tagstoClear = {"Monster", "Determination", "Rainbow", "White_Bone", "Blue_Bone" };

        foreach (string tag in tagstoClear)
        {
            GameObject[] objectsToClear = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objectsToClear){
                Destroy(obj);
            }
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

