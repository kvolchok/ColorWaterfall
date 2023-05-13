using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private int _mapWidth = 20;
    [SerializeField]
    private int _mapHeigth = 20;
    
    [SerializeField]
    private Vector2 _startSpawnPosition;
    [SerializeField]
    private float _nextSpawnDistance = 0.4f;
    
    [SerializeField]
    private float _nextSpawnDelay = 0.04f;
    
    [SerializeField]
    private Transform _cubePrefab;

    [SerializeField]
    private CoroutinesManager _coroutinesManager;

    private Transform[,] _cubes;

    private void Awake()
    {
        _cubes = new Transform[_mapWidth, _mapHeigth];
    }

    private void Start()
    {
        _coroutinesManager.StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        for (var y = 0; y < _cubes.GetLength(1); y++)
        {
            for (var x = 0; x < _cubes.GetLength(0); x++)
            {
                var spawnPosition = _startSpawnPosition + new Vector2(x, -y) * _nextSpawnDistance;
                _cubes[x, y] = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
                
                yield return new WaitForSeconds(_nextSpawnDelay);
            }
        }
    }

    public Transform[,] GetSpawnedCubes()
    {
        return _cubes;
    }
}