using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.05f;
    public float RotationSpeed = 0.15f;
    public Light DimmedLight;
    public GameObject Snowman;

    public UnityEvent UndergroundEvent;
    bool DidEvent = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0 && !DidEvent)
        {
            UndergroundEvent.Invoke();
            DidEvent = true;
        }
        else if (transform.position.y > 0 && DidEvent)
            DidEvent = false;

        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine("LightTestCoroutine");
        }

        if(Input.GetKeyDown(KeyCode.T))
            Invoke("InvokeExampleFunction", 5);

        if (Input.GetKeyDown(KeyCode.R))
            InvokeRepeating("InvokeRepeatingFunction", 5, 1);

        float RotationXDirection = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, RotationXDirection*RotationSpeed, 0));


        float RotationYDirection = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(RotationYDirection * RotationSpeed,0, 0));


        float VerticalDirection = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, VerticalDirection * Speed));
    }

    void InvokeExampleFunction()
    {
        Debug.Log("InvokeExampleFunction Ran");
    }

    void InvokeRepeatingFunction()
    {
        GameObject go = GameObject.Instantiate(Snowman);
        go.transform.position = transform.position;
    }

    IEnumerator LightTestCoroutine()
    {
        float dIntensity = 1.0f / 500.0f;
        for (int i = 0; i < 500; i++)
        {
            DimmedLight.intensity -= dIntensity;
            yield return null;
        }
    }

    public void TestFunction1()
    {
        Debug.Log("Event caused func 1");
    }

    public void TestFunction2()
    {
        Debug.Log("Event caused func 2");
    }


}
