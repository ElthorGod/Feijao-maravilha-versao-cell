using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasBox : MonoBehaviour
{
    public  Canvas canvas1;
    int fase ;
    // Start is called before the first frame update
    public void CanvasAtivo ()
    {
      fase = LevePass.levelPass.GetFaseAtual();

       if (fase == 2)
       {
        canvas1.gameObject.SetActive(true);
       }else
       {
        canvas1.gameObject.SetActive(false);
       }
    }
}
