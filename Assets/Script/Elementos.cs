using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Elementos : MonoBehaviour
{
    public GameObject elemento;
    public float veloxElemente;
    private Animator anim;

    private PlayerMoviment setPlayerMoviment;
    


    // Start is called before the first frame update
    void Start()
    {
      setPlayerMoviment = FindObjectOfType(typeof(PlayerMoviment)) as PlayerMoviment; 
      anim = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    void Update()
    {
        MoverElementos();
    }

     void MoverElementos()
    {
        transform.Translate(Vector2.down * veloxElemente * Time.deltaTime);
        if (transform.position.y < -6.05f)
        {
            elemento.SetActive(false);
        }
       
    }
   




}
