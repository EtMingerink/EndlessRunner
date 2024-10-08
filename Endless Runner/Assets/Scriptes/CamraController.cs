using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroler : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float cameraSpeed = 1;
    [SerializeField] bool lookAtPlayer;
    void Update()
    {
        if (player.transform.position.y > 0 == true)
        {
            //transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, cameraSpeed);
            if (lookAtPlayer == true)
            {
                transform.LookAt(player);
            }
        if (player.transform.position.y < 0 == false)
        {
            //transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            Vector3 targetPositionA = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPositionA, ref cameraVelocity, cameraSpeed);
            if (lookAtPlayer == true)
            {
                transform.LookAt(player);
            }
        }
        }
    }
}
