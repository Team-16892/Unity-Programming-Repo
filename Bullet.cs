using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject ImpactEffect;
    public void Seek(Transform Target)
    {
        target = Target;
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float MovementPerFrame = speed * Time.deltaTime;

        if(dir.magnitude <= MovementPerFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * MovementPerFrame, Space.World);

        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        
        Destroy(effect, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        
        
        Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy" )
            {
                Damage(collider.transform);
            }
        }
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
