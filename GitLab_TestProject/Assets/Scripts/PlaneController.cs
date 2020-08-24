using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 200.0f;
    [SerializeField] private float speed = 120.0f;
    [SerializeField] private float camOffset = 30.0f;
    [SerializeField] private float forwardOffset = 10.0f;
    [SerializeField] private float bias = 0.95f;

    private void Start()
    {
    }

    private void Update()
    {
        Vector3 moveCamTo = transform.position - transform.forward * forwardOffset + Vector3.up * forwardOffset;
        Camera.main.transform.position = (Camera.main.transform.position * bias / 1f) + (moveCamTo * (1.0f - bias));
        Camera.main.transform.LookAt(transform.position + transform.forward * camOffset * bias);


        transform.position += transform.forward * Time.deltaTime * speed;

        speed -= transform.forward.y * Time.deltaTime * 50.0f;

        if (speed < 35.0f)
        {
            speed = 35.0f;
        }
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }


        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeightWhereWeAre, transform.position.z);
        }
    }
}
