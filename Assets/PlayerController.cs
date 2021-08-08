using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 22;
    public GameManager gm;
    public AudioSource audioDie;
    public AudioSource audioPoint;
    public AudioSource audioWing;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            audioDie.Play();
            gm.PlayerDie();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PassZone")
        {
            audioPoint.Play();
            gm.AddPoint();
        }
    }
    void Update()
    {
        if ((Input.GetButtonDown("Jump") || (UserTap() == true && UserTapMenu() == false)) && GameManager.isGamePaused == false)
        {
            audioWing.Play();
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    bool UserTap()
    {
        bool didTap = false;
        foreach  (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                didTap = true;
            }
        }
        return didTap;
    }
    bool UserTapMenu()
    {
        bool didTapMenu = false;
        if (Input.touchCount > 0)
        {
            int pointerId = Input.touches[0].fingerId;
            if (EventSystem.current.IsPointerOverGameObject(pointerId))
            {
                didTapMenu = true;
            }
        }
        return didTapMenu;
    }
}
