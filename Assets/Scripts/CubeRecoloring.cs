using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRecoloring : MonoBehaviour
{
    [SerializeField]
    private CubeSpawner _cubeSpawner;

    [SerializeField]
    private float _recoloringDelay = 0.2f;

    [SerializeField]
    private CoroutinesManager _coroutinesManager;
    
    private List<Cube> _cubes;

    private void Start()
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
      
        for (var i = 0; i < _cubes.Count; i++)
        {
            var currentCube = _cubes[i];
            currentCube.ChangeColor(nextColor);
            yield return new WaitForSeconds(_recoloringDelay);
        }
    }
}