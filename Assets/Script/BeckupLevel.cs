using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeckupLevel : MonoBehaviour
{
    public LevePass setLevePass;
    public List<GameObject> cadeados = new List<GameObject>();
    int kad;

    // Start is called before the first frame update
    void Start()
    {
        kad = LevePass.levelPass.faseAtual;

        // Percorre a lista de cadeados
        for (int i = 0; i < cadeados.Count; i++)
        {
            Debug.Log("Cadeado " + i + ": " + cadeados[i].name);

            // Verifica a condição
            Debug.Log("O VALOR DE KAD " + kad);
            if (i >= kad)
            {
               Debug.Log("Cadeado " + i + " será removido!");
                // Remove o cadeado da lista
                Destroy(cadeados[i]);
                cadeados.RemoveAt(i);
                i--; // Ajusta o índice para continuar a verificação corretamente
            }

        }
    }

    // Resto do código...
}
