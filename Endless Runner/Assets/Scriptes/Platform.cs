using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float speed = 8;

    void Update()
    {
        //transform.Translate(-1, 0, 0);
        //transform.position = transform.position + new Vector3(-1, 0, 0);
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        if(transform.position.x < -20)
        {
            Destroy(gameObject);

        }
    }
}
