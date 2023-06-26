using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnador : MonoBehaviour
{
    public GameObject[] Spawnando;
    int random;
    public float tempoSpawn;
    public float delaySpawn;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnadorRandom",tempoSpawn,delaySpawn);
    }

    // Update is called once per frame
    void SpawnadorRandom ()
    {
        random = Random.Range(0,Spawnando.Length);
        Instantiate(Spawnando[random],transform.position,transform.rotation);
    }




}
