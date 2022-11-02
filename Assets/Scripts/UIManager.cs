using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vidas;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(GameManager.instance.vidas <= 0)
        {
           gameOver.SetActive(true);
        }

        if (GameManager.instance.vidas > 0)
        {
             tiempo.text = Time.time.ToString("00.00");
        }

            puntuacion.text = GameManager.instance.puntuacion.ToString();
        vidas.text = GameManager.instance.vidas.ToString();


    }
}
