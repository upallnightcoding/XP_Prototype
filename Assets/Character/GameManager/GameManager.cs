using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    //public event EventHandler OnFirer;

    // Start is called before the first frame update
    void Start()
    {
        //OnFirer += ShotFired;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //OnFirer?.Invoke(this, EventArgs.Empty);
        }
    }

    private void ShotFired(object sender, EventArgs args)
    {
        //Debug.Log("A shot was fired ...");
    }
}
