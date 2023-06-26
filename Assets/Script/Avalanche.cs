using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avalanche : MonoBehaviour
{
    private PlayerMoviment setPlayermoviment;
    public float maxAltura;
    public float minAltura;
    public float qtdSpawn;   //De quanto a quanto temopo spawna 
    public float tempoDeSpawn; // conta o tempo pra spawnar 
    public int   maxPedra;
    public GameObject prefabPedra;
    public List<GameObject> predas;     
    


    // Start is called before the first frame update
    void Start()
    {
        setPlayermoviment = FindObjectOfType(typeof(PlayerMoviment)) as PlayerMoviment;

         for (int i = 0; i < maxPedra; i++)
       {
        GameObject tempPedras = Instantiate(prefabPedra)as GameObject;
        predas.Add(tempPedras);
        tempPedras.SetActive(false);
       }
    }

    // Update is called once per frame
  
    void Update()
    {
      tempoDeSpawn += Time.deltaTime;
      if (tempoDeSpawn > qtdSpawn)
      {
        tempoDeSpawn = 0f;
        Spawnador();
      }
        
       
    }
    void Spawnador ()
    {
        float randowPosition = Random.Range (minAltura,maxAltura);
        GameObject tempPedras = null;
       
        for (int i = 0; i < maxPedra; i++)
       {
        if (predas[i].activeSelf == false)
        {
            tempPedras = predas[i];
            break;
        }
       }

       if (tempPedras !=null)
       {
        tempPedras.transform.position = new Vector3(randowPosition,transform.position.y,transform.position.z);
        tempPedras.SetActive(true);
       }
    }

   
}
 

   

