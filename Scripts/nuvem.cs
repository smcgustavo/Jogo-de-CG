using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuvem : MonoBehaviour
{
    public float speed = 10f;
    public Transform destino;
    public Vector3 comeco;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, destino.position) <= 40f)
        {
            transform.Translate(comeco, Space.World);
        }
    }
}
