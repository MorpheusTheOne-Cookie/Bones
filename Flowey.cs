
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;




public class Flowey : MonoBehaviour
{
    Animator anim;
    public AudioSource HitSound;
    public Image Bravery;
    public Image Integrity;
    public Image Justice;
    public Image Kindness;
    public Image Perseverance;
    public float hitResetTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Bravery.enabled && Integrity.enabled && Justice.enabled && Kindness.enabled && Perseverance.enabled && Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("Hit", true);
            HitSound.Play();
            StartCoroutine(ResetHit());
        }
    }

    private IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(hitResetTime); // Wait for the specified time
        anim.SetBool("Hit", false); // Reset "Hit" animation state
        HitSound.Stop();
    }
}
