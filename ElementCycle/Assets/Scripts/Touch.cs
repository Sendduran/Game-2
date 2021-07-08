using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{

    private bool isTouching = false;
    Rigidbody2D rb;
    Camera camera;
    CircleCollider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartTouch();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopTouch();
        }

        if (isTouching)
        {
            UpdateTouch();
        }
                
    }



    void UpdateTouch()
    {
        Vector2 touchPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        rb.position = touchPosition;
    }

    void StartTouch()
    {
        isTouching = true;
        circleCollider.enabled = true;
    }
    void StopTouch()
    {
        isTouching = false;
        circleCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroying");
        Destroy(collision.gameObject);
    }
}