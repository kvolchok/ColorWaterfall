using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private float _recoloringDuration = 0.5f;
    
    private Material _cubeMaterial;
    private Color _startColor;

    private float _currentTime;

    private void Awake()
    {
        _cubeMaterial = GetComponent<MeshRenderer>().material;
        _startColor = _cubeMaterial.color;
    }

    public IEnumerator ChangeColor(Color nextColor)
    {
        _currentTime = 0;

        while (_currentTime <= _recoloringDuration)
        {
            var recoloringProgress = _currentTime / _recoloringDuration;

            var currentColor = Color.Lerp(_startColor, nextColor, recoloringProgress);
            _cubeMaterial.color = currentColor;
            _currentTime += Time.deltaTime;

            yield return null;
        }
        
        _startColor = _cubeMaterial.color;
    }
}