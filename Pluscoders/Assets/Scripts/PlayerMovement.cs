using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 postion;
    public float speed;
    private Vector2 direction;
    public GameObject bullet;
    public float cooldown;
    private float timer;

    // Start is called before the first frame update
    private void Start()
    {
        //gameObject.transform.position = postion;
    }

    // Update is called once per frame
    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        if (Input.GetAxis("Fire1") == 1)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer -= cooldown;
                GameObject g = Instantiate(bullet, transform.position, Quaternion.identity);
                g.GetComponent<BulletMovement>().FromPlayer();
            }
        }

        transform.position = new Vector3(transform.position.x + speed * direction.x * Time.deltaTime, transform.position.y + speed * direction.y * Time.deltaTime, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}