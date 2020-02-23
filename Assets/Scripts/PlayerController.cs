using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed;
    public Vector2 moveVelocity;
    public Rigidbody2D rb;
    public bool isInLife;
    public GameObject bullet;
    Vector2 bulletPos;
    public float actualFireRate = 0.0f;
    float nextFire = 0.0f;

    public GameObject lifeObject;
    private Image lifeImage;

    public KeyCode dash;

    [SyncVar]
    public float life;
    private float resetlife;

    

    // Start is called before the first frame update
    void Start()
    {

        resetlife = life;
        rb = GetComponent<Rigidbody2D>();
        isInLife = true;
        lifeImage = lifeObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInLife == true)
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveVelocity = moveInput.normalized * moveSpeed;
        }

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + actualFireRate;
           
        }

        if (Input.GetKeyDown(dash))
        {
            Dash();
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void SetLife()
    {
        lifeImage.fillAmount = life / resetlife;
    }




    void Dash()
    {

    }

}
