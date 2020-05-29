using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float lifeTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Enemy")
        {
            Object.Destroy(col.gameObject);
            Object.Destroy(gameObject);
        }
    }
}
