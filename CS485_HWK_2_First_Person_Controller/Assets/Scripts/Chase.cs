using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target, Vector3.up);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TNT")
        {
            Destroy(collision.gameObject);
            Destroy(this);
            Destroy(gameObject);
        }
    }


}
