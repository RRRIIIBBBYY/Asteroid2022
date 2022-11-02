using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{   //Creamos variable de velocidad
    public GameObject spawnbullet;
    public GameObject bullet;
    public float speed= 10;
    public float rotationSpeed = 10;
    Rigidbody2D rb;
    Animator anim;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public Animator muerte;
    public AudioSource Audio;
    public AudioClip AudioMuerte;
   // public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {  
        float vertical = Input.GetAxis("Vertical");
        //Creamos condicional para el moviemiento para delante
        if(vertical > 0)
        {
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("impulsing", true);
            Audio.enabled = true;
        }
        else
        {
            anim.SetBool("impulsing", false);
            Audio.enabled = false;
        }
        //Creamos la rotacion del eje Z
        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal * -rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject temp = Instantiate(bullet, spawnbullet.transform.position, transform.rotation);
            Destroy(temp, 1.5f);
        }
    }

    public void Muerte()
    {  

       // GameObject temp = Instantiate( Particulas, transform.position, transform.rotation);
       // Destroy(temp, 0.18f);

        GameManager.instance.vidas -= 1;
        AudioSource.PlayClipAtPoint(AudioMuerte, transform.position);

        if (GameManager.instance.vidas <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Respawn_Coroutine());
        }

    }

    IEnumerator Respawn_Coroutine()
    {
        collider.enabled = false;
        sprite.enabled = false;
      
        
        muerte.SetBool("Explosion", true);
        yield return new WaitForSeconds(2);
        muerte.SetBool("Explosion", false);     
        sprite.enabled = true;
        StartCoroutine(Invencible());
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);


       


    }

    IEnumerator Invencible()
    {
        yield return new WaitForSeconds(2);
        collider.enabled = true;
    }
    
}
