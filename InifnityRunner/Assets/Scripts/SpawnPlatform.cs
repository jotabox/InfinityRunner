using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> plataformas = new List<GameObject>();
    public List<Transform> copiasPlataformas = new List<Transform>();

    public int distanciaPlataformas = 13;
    public int valorDistancias ;
    Transform Player;
    Transform plataformaAtual;
    public int indexPlataforma;




    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //test();
    }

    public void StartPlatform() 
    {
        for (int i = 0; i < plataformas.Count; i++)
        {
           Transform platforms = Instantiate(plataformas[i], new Vector2(distanciaPlataformas * i , 0), Quaternion.identity).transform;
            valorDistancias += distanciaPlataformas;
            copiasPlataformas.Add(platforms);
        }

        AtualPlataforma();

    }

    public void Move()
    {
        float distanciaPlataforma = Player.position.x -  plataformaAtual.position.x;
        if(distanciaPlataforma >= 1.5f)
        {
            Recycle(copiasPlataformas[indexPlataforma].gameObject);
            indexPlataforma++;

            if(indexPlataforma > copiasPlataformas.Count - 1)
            {
                indexPlataforma = 0;
            }

            AtualPlataforma();

        }
    }


    public void AtualPlataforma()
    {
        plataformaAtual = copiasPlataformas[indexPlataforma].GetComponent<Plataformas>().finalPlataformas;

    }
    public void Recycle(GameObject platforms)
    {
        platforms.transform.position = new Vector2(valorDistancias, 0f);
        valorDistancias += distanciaPlataformas;
    }
}
