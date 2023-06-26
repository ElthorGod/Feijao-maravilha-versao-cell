using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnimeMov : MonoBehaviour
{
    public float distancia;
     public float speedMovimento;
     public Transition transitions;

    bool eDireita = true;
    public Transform checaXaum;
    private      Animator  anim;

    private PlayerMoviment setPlaymoviment;

    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speedMovimento * Time.deltaTime);
        RaycastHit2D xaum = Physics2D.Raycast(checaXaum.position, Vector2.down, distancia );

        if(xaum.collider == false)
        {
            if (eDireita == true)
            {
                transform.eulerAngles = new Vector3(0,0,0);
                eDireita = false;
            }else
            {
                transform.eulerAngles = new Vector3(0,180,0);
                eDireita = true ;
            }
        }
   
    }
     private void OnTriggerEnter2D (Collider2D play )
    {
       if (play.tag == "feijao")
       {
          
       }
        
    }
}
