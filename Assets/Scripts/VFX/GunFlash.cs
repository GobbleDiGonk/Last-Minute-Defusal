using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlashScript: MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.11f);
    }
}
