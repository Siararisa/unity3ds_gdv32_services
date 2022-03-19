using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //private AudioSource source;
    private void Awake()
    {
        //source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //without a singleton, you need to have an instance of the class to access the functions
            //PlayerScore ps = collision.gameObject.GetComponent<PlayerScore>();
            //ps.AddScore(1);

            //but with a singleton, we can directly access the functions from the static instance instead
            ScoreManager.Instance.AddScore(1);
            AudioManager.Instance.PlaySound("Coin");
            //source.Play();
            Destroy(this.gameObject);
        }
    }
}
