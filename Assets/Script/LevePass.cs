using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class LevePass : MonoBehaviour
{
    // Start is called before the first frame update
  public static LevePass levelPass;
  public static Level level;
  
  public int faseAtual = 1;
  
  // use this fo initialization

  void Awake()
  {
    if (levelPass == null)
    {
        levelPass = this;
    }
    else if (levelPass != this)
    {
        Destroy(gameObject);
    }
    DontDestroyOnLoad(gameObject);
  }

  void Update ()
  {

  }
  public void LiberaFase(int faseALiberar)
  {
    if (faseALiberar > faseAtual)
    {
        faseAtual = faseALiberar;
        print(faseAtual + "faseliberada");
    }
  }
  public int GetFaseAtual ()
  {
    return faseAtual;
  }


}
