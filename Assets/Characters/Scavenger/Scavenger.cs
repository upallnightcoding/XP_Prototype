using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Throw()
    {
        //Instantiate(coin, firePoint.transform.position, Quaternion.identity);
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.position = firePoint.transform.position;
        ball.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    }
}
