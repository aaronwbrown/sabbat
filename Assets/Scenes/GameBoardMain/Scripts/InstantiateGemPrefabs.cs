using UnityEngine;
using System.Collections;

public class InstantiateGemPrefabs : MonoBehaviour
{
    public Transform Prefab;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }
}