using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 2;
    public float maxRotation = 10;
    private Rigidbody2D rb2d;
    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            // get a rotation that points Z axis forward, and the Y axis towards the target
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, (player.position - rb2d.position));

            // rotate toward the target rotation, never rotating farther than "lookSpeed" in one frame.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotation);
            rb2d.velocity = transform.up * startSpeed;
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
