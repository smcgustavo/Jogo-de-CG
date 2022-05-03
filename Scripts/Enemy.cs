using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int damage;
    private Transform target;
    private int wavePointIndex = 0;
    private bool isLookingLeft;

    // Start is called before the first frame update
    void Start()
    {
        isLookingLeft = false;
        target = Waypoints.points[wavePointIndex]; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            getNextWavePoint();
        }
        if(target.position.z - transform.position.z <= 0 && isLookingLeft == false)
        {
            Flip();
        }
        if (target.position.z - transform.position.z >= 0 && isLookingLeft == true)
        {
            Flip();
        }
    }
    void getNextWavePoint()
    {   
        if(wavePointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            causa_dano();
            return;
        }
        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }
    void causa_dano()
    {
        Player.recebe_dano(damage);
    }
    void Flip()
    {
        isLookingLeft = !isLookingLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}
