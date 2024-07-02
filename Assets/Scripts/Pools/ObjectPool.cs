using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object pool manager for GameObject instances.
/// </summary>
public class ObjectPool : MonoBehaviour
{
    /// <summary>
    /// The prefab used to instantiate objects for the pool.
    /// </summary>
    [SerializeField] private GameObject objectPrefab;

    /// <summary>
    /// Initial number of objects instantiated when the pool is created.
    /// </summary>
    [SerializeField] private int initialPoolSize = 10;

    /// <summary>
    /// Number of objects added to the pool when more instances are needed.
    /// </summary>
    [SerializeField] private int poolGrowthRate = 1;

    /// <summary>
    /// List to store references to the instantiated objects.
    /// </summary>
    [SerializeField] private List<GameObject> pool;

    /// <summary>
    /// Initializes the object pool by generating the initial pool of instances.
    /// </summary>
    void Start()
    {
        GeneratePoolInstances(initialPoolSize);
    }

    /// <summary>
    /// Generates a specified number of instances of the object prefab and adds them to the pool.
    /// </summary>
    /// <param name="amount">The number of instances to generate.</param>
    private void GeneratePoolInstances(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var instance = Instantiate(objectPrefab);
            instance.SetActive(false);
            instance.transform.parent = transform;
            pool.Add(instance);
        }
    }

    /// <summary>
    /// Returns an inactive instance from the pool, activating it for use.
    /// If no inactive instances are available, grows the pool and returns the new instance.
    /// </summary>
    /// <returns>An inactive GameObject instance from the pool.</returns>
    public GameObject GetInstance()
    {
        foreach (var instance in pool)
        {
            if (!instance.activeSelf)
            {
                instance.SetActive(true);
                return instance;
            }
        }

        GeneratePoolInstances(poolGrowthRate);

        var newInstance = pool[pool.Count - 1];
        newInstance.SetActive(true);
        return newInstance;
    }
}
