using System.Collections;
using UnityEngine;

public class CubeRecoloring : MonoBehaviour
{
    [SerializeField]
    private CubeSpawner _cubeSpawner;

    [SerializeField]
    private float _recoloringDelay = 0.2f;

    [SerializeField]
    private CoroutinesManager _coroutinesManager;
    
    private Transform[,] _cubes;

    private void Awake()
    {
        _cubes = _cubeSpawner.GetSpawnedCubes();
    }

    public void StartRecolorCubes()
    {
        _coroutinesManager.StartCoroutine(RecolorCubes());
    }

    private IEnumerator RecolorCubes()
    {
        var nextColor = Random.ColorHSV();
        
        for (var y = 0; y < _cubes.GetLength(1); y++)
        {
            for (var x = 0; x < _cubes.GetLength(0); x++)
            {
                var currentCube = _cubes[x, y].GetComponent<Cube>();
                _coroutinesManager.StartCoroutine(currentCube.ChangeColor(nextColor));
                yield return new WaitForSeconds(_recoloringDelay);
            }
        }
    }
}