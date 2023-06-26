using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaESeiva : MonoBehaviour
{
    
    public  GameObject agua; 
    public  GameObject seiva;

    public float tempo;
    
    private PlayerMoviment setMovimentaPlay;


    // Start is called before the first frame update
    void Start()
    {
        setMovimentaPlay = FindObjectOfType(typeof(PlayerMoviment)) as PlayerMoviment;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > tempo)
        {
            tempo = Time.time + tempo;
            GameObject spawnadordeAgua = Instantiate(agua, transform.position, Quaternion.identity);
            GameObject spawnadorSeiva = Instantiate(seiva, transform.position, Quaternion.identity);
            
        }
    }
}
