using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlsCell : MonoBehaviour
{
    public int auxDir;
    public float speed;
    public int uper;
    private Rigidbody2D feijaoPlayer;
    public float upforce = 40;
    private bool passoudeFase = false;
    private bool addForca = false;
    private Animator anim;
    public AudioSource audiosource;
    public bool gameover = false;
    public float velocidadeMovimento;
    public GameObject passouDefaseTxt;
    float pitch = 1.0f;
    public int faseALiberar;
    

    // sistema de Hud

    public int seiva;
    public float agua;
    public Text aguaTexto, seivaTexto;

    public Transition transitions;

    public ControledaCena setControleCena;




    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        feijaoPlayer = GetComponent<Rigidbody2D>();
        setControleCena = FindObjectOfType(typeof(ControledaCena)) as ControledaCena;
        anim = GetComponent<Animator>();
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        


    }

    // Update is called once per frame
    void Update()
    {
        
        if (!gameover && !passoudeFase)
        {
            float horizontal = Input.GetAxis("Horizontal"); // personagem planando 
            float vertical = Input.GetAxis ("Vertical");
            feijaoPlayer.velocity = new Vector2(horizontal * velocidadeMovimento, vertical = 0);
            
            if (auxDir != 0)
            {
                transform.Translate(speed * Time.deltaTime * auxDir, 0, 0);
                
            }
            if (addForca)
            {
                feijaoPlayer.velocity = Vector2.zero;
                feijaoPlayer.AddForce(new Vector2(0, upforce));
                addForca = false;
                
            }

        }
        if (agua <= 0)
        {
          gameover = true; 
          Debug.Log("tacerto");
          anim.SetTrigger("Gameover");
          transitions.Transicao("GameOver");
          upforce = 0f;
          feijaoPlayer.GetComponent<Rigidbody2D>().mass = 7f;
        }
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Brotou")
        {
            passoudeFase = true;
            SceneManager.LoadScene("LevelPass");
            LevePass.levelPass.LiberaFase(faseALiberar);
        }

          if (col.tag == "Zerou")
        {
            SceneManager.LoadScene("Level10");
        }

        if (col.tag == "Zerou")
        {
            passoudeFase = true;
            SceneManager.LoadScene("Level10");

        }


        if (col.tag == "ForçaAgua")           //triguer de colisão com a agua que adiciona 5
        {                                     //na agua, destroi o obj e muda o texto
            agua += 5;
            upforce += 10;
            aguaTexto.text = agua.ToString();
            Destroy(col.gameObject);

        }
        if (col.tag == "SeivaForce") //triguer que ao contao com o Obj seiva adiciona 1 e muda texto
        {
            seiva += 1;
            seivaTexto.text = seiva.ToString();
            Destroy(col.gameObject);
        }

        if (col.tag == "feijao")   // colisão do Game Over 
        {
            gameover = true;
            Debug.Log("colidiu ");
            anim.SetTrigger("Gameover");
            transitions.Transicao("GameOver");
        }
    }

    public void TouchHorizontal(int direcao)
    {
        auxDir = direcao;
    }

    public void Subir(int subiu)
    {
        uper = subiu;
    }
    public void OnPointerDown()
    {
        addForca= true;
    }
    public void GastarSeiva()
    {
        if (seiva > 0)
        {
            seiva--; 
            upforce += 20f;
            agua += 20f;
            Debug.Log("FUNCIONA");
            aguaTexto.text = agua.ToString();
            seivaTexto.text = seiva.ToString();
        }
    }
    public void GastaAgua()
    {
        if (agua > 0)
        {
            upforce -= 10f;
            agua    -= 5f;
            aguaTexto.text = agua.ToString();
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
    



}
