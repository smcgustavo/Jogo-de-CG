using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Unity Stuff")]
    private Animator playerAnimator;
    private int estado;
    private Transform target;
    private GameObject[] enemies;
    public string enemyTag = "Enemy";
    public bool isLookingLeft;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate;
    private float fireCountdown;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        estado = 1;
        isLookingLeft = true;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                nearestEnemy = enemy;
                shortestDistance = distanceToEnemy;
            }
        }
        
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        playerAnimator.SetInteger("Attacking", estado);
        if (target.position.z - transform.position.z <= 0 && isLookingLeft == false)
        {
            Flip();
        }
        if (target.position.z - transform.position.z >= 0 && isLookingLeft == true)
        {
            Flip();
        }
            
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void Flip()
    {
        isLookingLeft = !isLookingLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
    void Shoot()
    {
        Debug.Log("SHOOT");
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
