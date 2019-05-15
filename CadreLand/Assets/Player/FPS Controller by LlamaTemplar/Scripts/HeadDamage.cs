using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDamage : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public int health = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        //damaged = true;

        // amount = attackDamage;

        currentHealth -= amount;
        //  healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            //   SceneManager.LoadScene("GameOver");
        }

    }

    void OnCollisionEnter(Collider other)
    {



        /* Below is if we ever want to add health gain
        if (other.gameObject.CompareTag("Health"))
        {
            print("you gain health");
           // aud.PlayOneShot(chimeSnd);
            currentHealth += 10;
            GainHealth(10);
        }
        */

        if (other.gameObject.CompareTag("Water"))
        {
            print("you wet");
            health--;
            currentHealth -= 10;
            TakeDamage(10);
            // anim.SetTrigger("Hurt");
            // aud.PlayOneShot(hurtSnd);
            if (health < 0)
            {
                print("you dead");
                // SceneManager.LoadScene("GameOver");

            }


        }

    }
}
