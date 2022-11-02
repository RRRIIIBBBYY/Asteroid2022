using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideManager : MonoBehaviour
{
    public int asteroides_min = 2;
    public int asteroides_max = 4;
    public int asteroides;
    public float limitX = 10;
    public float limitY = 6;
    public GameObject asteroide;
    // Start is called before the first frame update
    void Start()
    {
        CrearAsteroides();
    }

    // Update is called once per frame
    void Update()
    {
        if(asteroides <= 0)
        {
            asteroides_min += 2;
            asteroides_max += 2;
            CrearAsteroides();
        }
       
    }
    void CrearAsteroides()
    {
        int asteroides = Random.Range(asteroides_max, asteroides_min);


        for (int i = 0; i < asteroides; i++)
        {
            
            Debug.Log("instanciando el asteroide:" + i);
            Vector3 position = new Vector3(Random.Range(-limitX, limitY), Random.Range(-limitY, limitY));

            while (Vector3.Distance(position, new Vector3(0, 0, 0)) < 5)
            {
                position = new Vector3(Random.Range(-limitX, limitY), Random.Range(-limitY, limitY));
            }
            
            Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
            GameObject temp = Instantiate(asteroide, position, Quaternion.Euler(rotation));
            temp.GetComponent<AsteroidControl>().manager = this;
        }


    }

}
