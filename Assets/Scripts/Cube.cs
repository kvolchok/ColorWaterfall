using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private float _recoloringDuration = 0.5f;
    
    private Material _cubeMaterial;

    private void Awake()
    {
        _cubeMaterial = GetComponent<MeshRenderer>().material;
    }

    public IEnumerator ChangeColor(Color endColor)
    {
        var startColor = _cubeMaterial.color;
        var currentTime = 0f;

        while (currentTime <= _recoloringDuration)
        {
            var recoloringProgress = currentTime / _recoloringDuration;

            var currentColor = Color.Lerp(startColor, endColor, recoloringProgress);
            _cubeMaterial.color = currentColor;
            currentTime += Time.deltaTime;

            yield return null;
        }
    }
}