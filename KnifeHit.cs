using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KnifeHit : MonoBehaviour
{
    Rigidbody2D rb;
    Islemler kod;
    AudioSource kaynak;
    public AudioClip ses;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        kod = GameObject.Find("Islemler").GetComponent<Islemler>();
        kaynak = this.GetComponentInParent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="alt" ||  other.gameObject.tag=="trap")
        {
            kaynak.PlayOneShot(ses);
            rb.velocity = new Vector2(rb.velocity.x,-20.0f);
            kod.gameover = true;
        }
    }


}
