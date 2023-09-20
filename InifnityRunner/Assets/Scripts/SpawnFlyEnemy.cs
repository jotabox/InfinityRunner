using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlyEnemy : MonoBehaviour
{

    public List<GameObject> listaInimigos = new List<GameObject>();
    private float tempoDeSpawn = 2;
    private float tempoAtual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtual += Time.deltaTime;
        if (tempoAtual >= tempoDeSpawn)
        {
            Spawn();
            tempoAtual = 0;
        }

    }

    void Spawn()
    {
        GameObject inimigo;
        for (int i = 0; i < listaInimigos.Count; i++)
        {
            inimigo = Instantiate(listaInimigos[i],transform.position,Quaternion.identity);
        }


    }
}
