using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _scaleDivider;
    [SerializeField] private float _chanceDivider;
    [SerializeField] private int minSpawnCount;
    [SerializeField] private int maxSpawnCount;

    public List<Cube> SpawnCubes(Cube parentCube)
    {
        List<Cube> newCubes = new List<Cube>();
        int cubesSpawnQuantity = Random.Range(minSpawnCount, maxSpawnCount);
        Vector3 parentPosition = parentCube.transform.position;
        Vector3 parentScale = parentCube.transform.localScale;

        for (int i = 0; i < cubesSpawnQuantity; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * parentPosition.magnitude / _scaleDivider;
            randomOffset.y = Mathf.Abs(randomOffset.y);
            Vector3 spawnPosition = (parentPosition + randomOffset) / _scaleDivider;

            Cube newCube = Cube.Instantiate(_prefab, spawnPosition, Quaternion.identity);
            newCube.transform.localScale = parentScale / _scaleDivider;
            newCube.Initialize(parentCube.SplitÑhance / _chanceDivider);
            newCube.MeshRenderer.material.color = RandomColor.GetRandomColor();

            newCubes.Add(newCube);
        }

        return newCubes;
    }
}