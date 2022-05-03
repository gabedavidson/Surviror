using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rb;
    public Camera cam;
    public SpriteRenderer HeroRenderer;

    private Vector2 movement;
    private Vector2 mousePos;

    void Awake()
    {
        HeroParameters.heroTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        HeroParameters.heroTransform = gameObject.transform;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        // SpriteTools.ConstrainToScreen(HeroRenderer);
    }
}
