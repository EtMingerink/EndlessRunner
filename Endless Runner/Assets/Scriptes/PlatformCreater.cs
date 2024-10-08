using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreater : MonoBehaviour
{


    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform referencePoint;
    [SerializeField] private GameObject lastCreatedPlatform;
    [SerializeField] byte spaceBetweenPlatforms = 1;
    float lastPlatformWidth;
    void Start()
    {
        //lastCreatedPlatform = Instantiate(platformPrefab, referencePoint.position, Quaternion.identity);
    }

    void Update()
    {
        
        if (lastCreatedPlatform.transform.position.x < referencePoint.position.x)
        {
            Vector3 targetCreationPoint = new Vector3(referencePoint.position.x + lastPlatformWidth +spaceBetweenPlatforms, 0, 0);
            int randomPlatform = Random.Range(0, 3);
            lastCreatedPlatform = Instantiate(platformPrefab[randomPlatform], targetCreationPoint, Quaternion.identity);
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }

    }
}