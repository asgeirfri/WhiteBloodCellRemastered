using UnityEngine;

public class Player : MonoBehaviour
{
    public float startSpeed = 2;
    private Rigidbody2D rb2d;
    public GameObject shotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("LaunchProjectile", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector2 fingerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 delta = (fingerPosition - rb2d.position);
        if (delta.magnitude > 0.1)
        {
            Vector2 direction = delta.normalized;
            rb2d.velocity = (direction * startSpeed); // Add delta
        }
        else
        {
            rb2d.velocity = (new Vector2(0, 0));
        }
    }

    void LaunchProjectile()
    {
        Vector2 fingerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (fingerPosition - rb2d.position).normalized;
        GameObject shot = Instantiate(shotPrefab, rb2d.position, Quaternion.identity) as GameObject;
        shot.GetComponent<Rigidbody2D>().velocity = (direction * -1 * 3);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        print(other.gameObject.tag);
        if (other.gameObject.tag == "Shot")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
        if (other.gameObject.tag == "Enemy")
        {
            print("Enemy");
            Die();
        }
    }

    public void Die()
    {
        Object.Destroy(gameObject);
        // Todo: end game
    }
}