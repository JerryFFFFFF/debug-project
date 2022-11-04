using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friends : MonoBehaviour
{
    public Vector2 ferryScaleRange;
    public Vector2 moveSpeedRange;

    [HideInInspector]
    public float ferryScale;
    float moveSpeed;



    public void SpawnFerry()
    {
       ferryScale = Random.Range(ferryScaleRange.x, ferryScaleRange.y );
       moveSpeed = Random.Range(moveSpeedRange.x,moveSpeedRange.y);

        transform.localScale = Vector3.one* ferryScale;
    }

    void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }
}
