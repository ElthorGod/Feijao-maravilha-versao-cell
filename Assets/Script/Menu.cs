using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public string cena;

    public Transition transitions;

     public GameObject instrução;
     public GameObject controles;
     public GameObject Painel;
    
     public bool chave = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void LoadingScena ()
    {
        transitions.Transicao(cena);
    }

    public void Instru ()
    {
        SceneManager.LoadScene("Controles");
    }

    public void TrocaBtn () // serve para os botões ativar e desativar os textos da instrução 
    {
        if (instrução.activeInHierarchy == true)
        {
            instrução.SetActive(false);
            controles.SetActive(true);
        }
        else
        {
            instrução.SetActive(true);
            controles.SetActive(false);
            
        }       
    }
    public void PainelSons()
    {   
        if (Painel.activeInHierarchy == true)
        {
            Painel.SetActive(false);
        }
        else
        {
            Painel.SetActive(true);
        }

    }

    public void Telaprincipal ()
    {
        SceneManager.LoadScene("Menu");
    }


      public void QuitGame ()
    {    
        Application.Quit();
    }

    public void Mutar(bool mudo)
    {
        if (mudo) 
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 0.40f; 
        }
    }

}
