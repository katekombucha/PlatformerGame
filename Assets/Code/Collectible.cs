using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float animationDuration = 0.3f;
    private void OnTriggerEnter2D(Collider2D col)
    {
        ScoreManager.Instance.AddPoint();
        LerpPosition.Instance.MoveTo(transform, transform.position + Vector3.up * 0.2f, animationDuration);
        Destroy(gameObject, animationDuration + 0.1f);
    }
}