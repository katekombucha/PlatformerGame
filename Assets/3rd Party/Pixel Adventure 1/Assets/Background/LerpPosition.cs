using System.Collections;
using UnityEngine;

// Стаття про Lerp (Linear Interpolation):
// https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/
public class LerpPosition : MonoBehaviour
{
    public static LerpPosition Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }
    
    public void MoveTo (Transform transformToMove, Vector2 positionToMoveTo, float duration)
    {
        StartCoroutine(Lerp(transformToMove, positionToMoveTo, duration));
    }

    private IEnumerator Lerp(Transform transformToMove, Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transformToMove.position;

        while (time < duration)
        {
            transformToMove.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transformToMove.position = targetPosition;
    }
}
