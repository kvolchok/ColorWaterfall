using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private float _recoloringDuration = 0.5f;
    
    private Material _cubeMaterial;
    private Color _startColor;
    
    private void Awake()
    {
        _cubeMaterial = GetComponent<MeshRenderer>().material;
        _startColor = _cubeMaterial.color;
    }

    public IEnumerator ChangeColor(Color nextColor)
    {
        var currentTime = 0f;

        while (currentTime <= _recoloringDuration)
        {
            var recoloringProgress = currentTime / _recoloringDuration;

            var currentColor = Color.Lerp(_startColor, nextColor, recoloringProgress);
            _cubeMaterial.color = currentColor;
            currentTime += Time.deltaTime;

            yield return null;
        }
        
        _startColor = _cubeMaterial.color;
    }
}