using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{   //Creamos variable de velocidad
    public float speed= 10;
    public float rotationSpeed = 10;
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        }
        else
        {
            anim.SetBool("impulsing", false);
        }
        //Creamos la rotacion del eje Z
        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal * -rotationSpeed * Time.deltaTime);
    }
}
