using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour {

    private float force = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.transform.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * force, ForceMode2D.Impulse);
        }
    }
}
