using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerMoviment : MonoBehaviour
{

    int cont;
    private Rigidbody2D feijaoPlayer;
    private bool        passoudeFase = false;
    private Animator    anim;
    public  AudioSource audiosource;
    public  bool        gameover = false;
    public  float       velocidadeMovimento;
    public  float       upforce = 400;
    public GameObject   passouDefaseTxt;
    float               pitch = 1.0f;
    public int          faseALiberar;
   
    

    // sistema de Hud


    public int   seiva;
    public float agua;
    public Text aguaTexto, seivaTexto;

    public Transition transitions;

    public ControledaCena setControledeCena;
    public ControlsCell controlsCell;
    
    // Start is called before the first frame update
    void Start()
    {
             
   
        setControledeCena = FindObjectOfType(typeof(ControledaCena)) as ControledaCena;
        feijaoPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("contagemDeAgua");
      

    }

    // Update is called once per frame
    void Update()
    {
        GastaAgua();
        GastaSeiva();
     
        
        if(!gameover && !passoudeFase)
        {
        float horizontal = Input.GetAxis("Horizontal"); // personagem planando 
        float vertical = Input.GetAxis ("Vertical");
        feijaoPlayer.velocity = new Vector2(horizontal * velocidadeMovimento, vertical = 0);
        
       
        if(Input.GetKeyDown(KeyCode.Space)) // personagem subindo
        {
            feijaoPlayer.velocity = Vector2.zero;
            feijaoPlayer.AddForce(new Vector2(0,upforce));
            anim.SetTrigger("apertando");  // parametro pra chama animação
            
        }

    
        }
    }
  
     IEnumerator contagemDeAgua()
    {
        aguaTexto.text = agua.ToString();
        yield return new WaitForSeconds(0.1f);

        
        
        if (agua > 0)
        {
            StartCoroutine("contagemDeAgua");
        }
        else
        {
            anim.SetTrigger("Gameover");
            transitions.Transicao("GameOver");

        }
    }
   
    void OnTriggerEnter2D( Collider2D col)
   {
    //colisoes 
    if (col.tag == "Brotou" )
    // passa a fase 
    {
        passoudeFase = true;
        SceneManager.LoadScene("PassFase");
        LevePass.levelPass.LiberaFase(faseALiberar);            
    }

    
    if (col.tag == "Zerou" )
    //zera o jogo
    {
        passoudeFase = true;
        SceneManager.LoadScene("Level10");
               
    }

    //apanha a agua 
    if (col.tag == "ForçaAgua")
    {
        agua += 5;
        upforce += 10;
        aguaTexto.text = agua.ToString();
        Destroy(col.gameObject);
      
    }  
      if (col.tag == "SeivaForce")
        //apanha seiva
        {
            seiva += 1;
            seivaTexto.text = seiva.ToString();
            Destroy(col.gameObject);
        }
     
        if (col.tag == "feijao")
        // colide com os obj e da game over
        {
            gameover = true;
            Debug.Log ( "colidiu ");
            anim.SetTrigger("Gameover");
            transitions.Transicao("GameOver");
        }
   }

    void GastaAgua ()
    {   //metodo para gastar agua enquanto o botao e apertado....ele é com mesmo acionamento do botão que faz subir o player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            upforce -=5;
            agua -=5f;
        }
        if (agua < 0)
        {
            gameover = true;
            aguaTexto = null;
        }
        if (agua < 40)
        {
            // Define o pitch do áudio como 1.6 se a água estiver abaixo de 40
            if (Mathf.Approximately(audiosource.pitch, 1.0f))
            {
                audiosource.pitch = 1.6f;
            }
        }
        else
        {
            // Define o pitch do áudio como 1.0 se a água estiver acima ou igual a 40
            if (Mathf.Approximately(audiosource.pitch, 1.6f))
            {
                audiosource.pitch = 1.0f;
            }
        }
    }
    
    void GastaSeiva ()
    {
        // metodo para gastar seiva verde enquanto o botão e apertado 
        if (Input.GetKeyDown(KeyCode.B) && seiva >= 1 )
        {
            agua +=20f;
            seiva -=1;
            upforce +=50;
            Debug.Log("FUNCIONA");
        }else
        {
            seivaTexto.text = seiva.ToString();
            
        }
        
    }
  

}
