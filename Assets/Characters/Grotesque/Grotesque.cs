using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grotesque : MonoBehaviour
{
    private GrotState state = GrotState.HIDDEN;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GrotState
{
    IDLE = 0,
    RUN = 1,
    SPAWN = 2,
    BUILD = 3,
    HIDDEN = 4
}
