using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{

    private Transform player;
    public int speedCamera = 5;
    public int posicaoCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = new Vector3(player.position.x + posicaoCamera, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, cameraPos, speedCamera * Time.deltaTime);
    }
}
