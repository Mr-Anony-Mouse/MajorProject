using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}