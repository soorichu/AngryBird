using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
