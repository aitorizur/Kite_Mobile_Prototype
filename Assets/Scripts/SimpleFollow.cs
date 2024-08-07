using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    [SerializeField] private Transform objective = null;
    [SerializeField] [Range(0.5f, 10.0f)] private float lerpSpeed = 6.0f;

    private Vector3 startingDistance;
    private Vector3 targetPosition;

    void Awake()
    {
        startingDistance = transform.position - objective.transform.position;
    }

    void Update()
    {
        UpdateTargetPosition();
        LerpToTargetPosition();
    }

    private void UpdateTargetPosition()
    {
        targetPosition = objective.transform.position + startingDistance;
    }

    private void LerpToTargetPosition()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
