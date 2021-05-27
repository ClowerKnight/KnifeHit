using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : MonoBehaviour
{
    public float hiz;
    Rigidbody2D rb;
    public bool hazir;
    Islemler erisim;
    BoxCollider2D col;
    AudioSource kaynak;
    public AudioClip seshedef;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hazir = true;
        erisim = GameObject.Find("Islemler").GetComponent<Islemler>();
        col = GetComponent<BoxCollider2D>();
        kaynak = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.touchCount>0 &&hazir)
        {
            Firlatma();
        }
    }


    void Firlatma()
    {
        rb.velocity = new Vector2(0,hiz);
        hazir = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name=="Hedef")
        {
            kaynak.PlayOneShot(seshedef);
            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);
            transform.SetParent(other.transform);
            col.enabled = false;

            erisim.Spawn();
        }
    }

}

