using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _scaleDivider;
    [SerializeField] private float _chanceDivider;
    [SerializeField] private int minSpawnCount;
    [SerializeField] private int maxSpawnCount;

    private ColorGenerate _colorGenerate;
    
    private void Awake()
    {
        _colorGenerate = new ColorGenerate();
    }

    public List<Cube> SpawnCubes(Cube parentCube)
    {
        List<Cube> newCubes = new List<Cube>();
        int cubesSpawnQuantity = Random.Range(minSpawnCount, maxSpawnCount);
        Vector3 parentPosition = parentCube.transform.position;
        Vector3 parentScale = parentCube.transform.localScale;

        for (int i = 0; i < cubesSpawnQuantity; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * parentPosition.magnitude * 0.1f;
            randomOffset.y = Mathf.Abs(randomOffset.y);
            Vector3 spawnPosition = parentPosition + randomOffset;

            Cube newCube = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            newCube.transform.localScale = parentScale / _scaleDivider;
            newCube.Initialize(parentCube.SplitChance / _chanceDivider);
            newCube.MeshRenderer.material.color = _colorGenerate.Generate();

            newCubes.Add(newCube);
        }

        return newCubes;
    }
}