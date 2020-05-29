using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float startSpeed = 2;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 fingerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (fingerPosition - rb2d.position).normalized;

        rb2d.velocity = (direction * startSpeed);
    }
}
