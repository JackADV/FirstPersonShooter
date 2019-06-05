using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    public int damage = 10;
    public float speed = 10f; // Speed of the bullet
    private Rigidbody rigid;
    public Transform line;
    public GameObject effectPrefab;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>(); // Calls the rigid body
    }

    void Update()
    {
        if(rigid.velocity.magnitude > 0f)
        {
            line.rotation = Quaternion.LookRotation(rigid.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (effectPrefab)
        // {
        // Get the contact point
        //     ContactPoint contact = collision.contacts[0];
        // Spawn the effect - and rotate to contact normal
        //Instantiate(effectPrefab, contact.point, Quaternion.LookRotation(contact.normal));
        // }
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }
        
        // Destroy bullet
        Destroy(gameObject);
    }

    public override void Fire(Vector3 lineOrigin, Vector3 direction)
    {
        rigid.AddForce(direction * speed, ForceMode.Impulse);
        line.position = lineOrigin;
    }

    
}
