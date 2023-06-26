using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static Level level; // adiciona uma variável estática level


    public void Awake()
    {
        if (level == null)
        {
            level = this;
        }
        else if (level != this)
        {
            Destroy(gameObject);
        }
    }

    public void CarregarLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void CarregaFase(int fase)
    {
        if (fase <= LevePass.levelPass.GetFaseAtual())
        {
        
            SceneManager.LoadScene(fase);
        }
        else
        {
            return;
        }
    }



   
}
