using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance_this_frame = speed * Time.deltaTime;

        if (dir.magnitude <= distance_this_frame)
        {
            HitTarget();
            Destroy(gameObject);
            return;
        }

        transform.Translate(distance_this_frame * dir.normalized, Space.World);

    }

    void HitTarget()
    {
        Debug.Log("We Hit Something!");
    }

}
