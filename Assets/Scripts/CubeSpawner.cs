using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private int _mapWidth = 20;
    [SerializeField]
    private int _mapHeigth = 20;
    
    [SerializeField]
    private Transform _startSpawnPoint;
    [SerializeField]
    private float _nextSpawnDistance = 0.4f;
    
    [SerializeField]
    private float _nextSpawnDelay = 0.04f;
    
    [SerializeField]
    private Cube _cubePrefab;

    [SerializeField]
    private CoroutinesManager _coroutinesManager;
    
    private readonly List<Cube> _cubes = new();

    private void Start()
    {
        _coroutinesManager.StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        for (var y = 0; y < _mapWidth; y++)
        {
            for (var x = 0; x < _mapHeigth; x++)
            {
                var spawnPosition = _startSpawnPoint.position
                                    + new Vector3(x, -y) * _nextSpawnDistance;
                var cube = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
                _cubes.Add(cube);

                yield return new WaitForSeconds(_nextSpawnDelay);
            }
        }
    }

    public List<Cube> GetSpawnedCubes()
    {
        return _cubes;
    }
}