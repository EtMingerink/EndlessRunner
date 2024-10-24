using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentalControler : MonoBehaviour
{
    [SerializeField] GameObject environmentElement;
    [SerializeField] Transform referencePoint;

    
    void Start()
    {
        //Debug.Log(SumOfTwoNumbers(4, 9));
        StartCoroutine(CreateEnvironmentElement());
    }



    /*int SumOfTwoNumbers(int number1, int number2)
    {
        return number1 + number2;
    }*/

    IEnumerator CreateEnvironmentElement()
    {
        if (environmentElement != null && referencePoint != null)
        {
            Instantiate(environmentElement, referencePoint.position, Quaternion.identity);
            yield return new WaitForSeconds(3);
            StartCoroutine(CreateEnvironmentElement());
        }
        else
        {
            Debug.LogError("environmentElement or referencePoint is not assigned!");
        }
    }
}

