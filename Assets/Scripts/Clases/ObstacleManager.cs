using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private ObjectPooling objPool;

    private void Start()
    {
        objPool = GameObject.Find("Pool").GetComponent<ObjectPooling>();
        objPool.RequestObject();
    }
}
