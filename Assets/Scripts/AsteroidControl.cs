using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    public AsteroideManager manager;
    Rigidbody2D rb;
    public float speed_min;
    public float speed_max;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction = direction * Random.Range(speed_min, speed_max);
        rb.AddForce(direction);
        manager.asteroides += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Muerte()
    {
        if (transform.localScale.x > 0.25f)
        {
            GameObject temp1 = Instantiate(manager.asteroide, transform.position, transform.rotation);
            temp1.GetComponent<AsteroidControl>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;

            GameObject temp2 = Instantiate(manager.asteroide, transform.position, transform.rotation);
            temp2.GetComponent<AsteroidControl>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;
        }
        GameManager.instance.puntuacion += 100;
        manager.asteroides -= 1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playermove>().Muerte();
        }
    }
}
