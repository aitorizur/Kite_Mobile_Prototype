using UnityEngine;

public class DirectionController : MonoBehaviour
{
    public Vector2 direction = Vector2.zero;
    public float rotation = 0.0f;

    [SerializeField] private AnimationCurve rotationCurve = null;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            direction = ((Vector2)Input.mousePosition - (Vector2)transform.position).normalized;
        }
        else
        {
            direction = Vector2.zero;
        }

        rotation = rotationCurve.Evaluate((Input.mousePosition.x / (float)Screen.width) - 0.5f);
        Debug.Log(rotation);
    }
}
