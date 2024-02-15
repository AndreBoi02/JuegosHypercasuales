using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private List<GameObject> availableObjectsList;
    private List<GameObject> UnavailableObjectsList;

    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        availableObjectsList = new List<GameObject>();
        UnavailableObjectsList = new List<GameObject>();
    }

    void Start()
    {
        CreateObjects(poolSize);
    }

    void CreateObjects(int poolSize)
    {
        GameObject tempObject;
        for (int i = 0; i < poolSize; i++)
        {
            tempObject = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
            tempObject.SetActive(false);
            availableObjectsList.Add(tempObject);
        }
    }

    public GameObject RequestObject()
    {
        if (availableObjectsList.Count != 0)
        {
            GameObject requestedObject = availableObjectsList[0];
            availableObjectsList.Remove(requestedObject);
            UnavailableObjectsList.Add(requestedObject);
            requestedObject.SetActive(true);
            return requestedObject;
        }
        else
        {
            CreateObjects(1);            
            return RequestObject();
        }
    }

    public void DespawnObject(GameObject object2Despawn)
    {
        object2Despawn.SetActive(false);
        availableObjectsList.Add(object2Despawn);
        UnavailableObjectsList.Remove(object2Despawn);
    }
}
