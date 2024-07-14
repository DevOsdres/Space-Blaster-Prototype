using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitDestroy : MonoBehaviour
{
    private float topLimit = 160;
    private float bottomLimit = -160;

    void Update()
    {
        if (transform.position.z > topLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
