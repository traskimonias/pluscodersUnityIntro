using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
    }

    public void FromPlayer()
    {
        gameObject.tag = "Player";
        gameObject.layer = 9;

        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.right * speed;
    }

    public void FromEnemy()
    {
        gameObject.tag = "Enemy";
        gameObject.layer = 8;
        rb = GetComponent<Rigidbody>();
        rb.velocity = -Vector3.right * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
    }
}