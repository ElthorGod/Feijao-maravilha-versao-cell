using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentador : MonoBehaviour
{
    
    public bool xaonovo = false;
    private bool gameover = false;

    public ControledaCena setControleCena;

    private int move;



    // Start is called before the first frame update
    void Start()
    {
        setControleCena = FindObjectOfType(typeof(ControledaCena)) as ControledaCena;
    }

    // Update is called once per frame
  

        void FixedUpdate()
    {
        
    }
    
    void Update()
    {
        MoverXao();
        
       
        if (xaonovo == false )
        {
            if (transform.position.y <= 0 && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
            {
                xaonovo = true;
                GameObject Xaotemporario = Instantiate(setControleCena.prefabXao);   
                Debug.Log ( "Instanciou o Xao ");
                Xaotemporario.transform.position = new Vector3(transform.position.x, transform.position.y + setControleCena.tamanhodoXao, 0);
                
            }
            if (transform.position.y <= 0 &&  move != 0)
            {
                xaonovo = true;
                GameObject Xaotemporario = Instantiate(setControleCena.prefabXao);   
                Debug.Log ( "Instanciou o Xao ");
                Xaotemporario.transform.position = new Vector3(transform.position.x, transform.position.y + setControleCena.tamanhodoXao, 0);
            }

        }   
        
        if (transform.position.y < setControleCena.xaoDestroy) // 10.7
        {
            Destroy(this.gameObject);
        }

        

    }


  public void MoverXao()
{
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
    {
        transform.Translate(Vector2.down * setControleCena.velocidadeXao * Time.deltaTime);
    }
    if (move != 0)
    {
        transform.Translate(Vector2.down * setControleCena.velocidadeXao * Time.deltaTime);
    }
}
    public void MoverXaoCell (int movendo)
    {
        move = movendo;
    }
public void OnButtonClick()
{
    MoverXao();
}







}
