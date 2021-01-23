using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxSpeed;
    private float speed;
    public float maxTimer;
    private float timer;
    private bool ragdoll = false;
    public float maxFire;
    private float fireTimer;
    public GameObject bullet;

    // Start is called before the first frame update
    private void Start()
    {
        speed = maxSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            timer -= maxTimer;
            speed = -speed;
        }
        fireTimer += Time.deltaTime;
        if (fireTimer > maxFire)
        {
            fireTimer -= maxFire;
            GameObject g = Instantiate(bullet, transform.position, Quaternion.identity);
            g.GetComponent<BulletMovement>().FromEnemy();
        }
        if (ragdoll == false) transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ragdoll = true;
            Destroy(gameObject, 2f);
            Destroy(collision.gameObject);
        }
    }
}