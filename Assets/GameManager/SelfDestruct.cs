using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelfDestruct : MonoBehaviour
{
    public abstract void selfDestruct(string missileName);

    public abstract void renew();
}
