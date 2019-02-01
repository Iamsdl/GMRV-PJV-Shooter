using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    private float fuel;
    public float Fuel
    {
        get
        {
            return fuel;
        }
    }
    public GameObject fuelBar;
    public Image boostImage;
    public float score;
    private float boostCooldown;
    private float BoostCooldown
    {
        get
        {
            return boostCooldown;
        }
        set
        {
            boostCooldown = value;
            boostImage.fillAmount = 1 - value * 0.2f;
        }
    }

    internal void AddFuel(float amount)
    {
        this.fuel += amount;
    }

    private float shipRotationSpeed;
    private float shipRotationAngle;
    private float thrusterForce;
    public Weapon weapon;
    private float attackSpeed;
    private float bulletThrusterForce;
    private Vector2 dir;

    public Camera playerCamera;
    private Camera minimapCamera;

    private Rigidbody2D rb;

    private float upAxis;
    private float rightAxis;
    private bool isShooting;
    public float fuelEfficiency;
    public float maxFuel;
    public List<string> inventory;

    public GameObject W;
    public GameObject A;
    public GameObject S;
    public GameObject D;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<string>();
        fuel = maxFuel;
        score = 0;
        attackSpeed = 1.0f;
        shipRotationSpeed = 150.0f;
        thrusterForce = 10.0f;
        dir = new Vector2(0, 1);
        rb = this.GetComponent<Rigidbody2D>();

        shipRotationAngle = shipRotationSpeed * Time.fixedDeltaTime;

        minimapCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    internal void AddScore(float maxHealth)
    {
        score += maxHealth * GameController.difficulty;
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);

        if (hit)
        {
            dir = hit.point - new Vector2(transform.position.x, transform.position.y);
        }

        #region Shooting
        if (Input.GetMouseButtonDown(0))
        {
            this.isShooting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.isShooting = false;
        }
        #endregion

        #region WASD
        if (Input.GetKeyDown(KeyCode.W))
        {
            W.SetActive(true);
            upAxis++;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            W.SetActive(false);
            upAxis--;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            S.SetActive(true);
            upAxis -= 0.8f;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            S.SetActive(false);
            upAxis += 0.8f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            D.SetActive(true);
            rightAxis += 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            D.SetActive(false);
            rightAxis -= 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            A.SetActive(true);
            rightAxis -= 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            A.SetActive(false);
            rightAxis += 0.5f;
        }
        #endregion

        #region Space
        if (Input.GetKey(KeyCode.Space))
        {
            BoostIfPossible();
        }
        #endregion
    }

    public void BoostIfPossible()
    {
        if (BoostCooldown <= 0)
        {
            BoostCooldown = 5;
        }
    }

    private void FixedUpdate()
    {
        #region Movement
        float angle = Vector2.SignedAngle(this.transform.up, dir);
        if (angle <= -shipRotationAngle / 2 || angle > shipRotationAngle / 2)
        {
            if (Mathf.Sign(angle) == 1)
            {
                transform.Rotate(0, 0, Mathf.Min(angle, shipRotationAngle));
            }
            else
            {
                transform.Rotate(0, 0, Mathf.Max(angle + 360, 360 - shipRotationAngle));
            }
        }

        if (fuel > 0)
        {
            fuel -= (Math.Abs(upAxis) + Math.Abs(rightAxis)) * fuelEfficiency * Time.fixedDeltaTime;
            fuelBar.transform.localScale = new Vector3(fuel / maxFuel, 1, 1);
            rb.AddForce(thrusterForce * (this.transform.up * upAxis + this.transform.right * rightAxis));
        }

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -GameController.TerminalVelocity, GameController.TerminalVelocity), Mathf.Clamp(rb.velocity.y, -GameController.TerminalVelocity, GameController.TerminalVelocity));

        float playerHeightRelativeToMinimap = this.transform.position.y - minimapCamera.transform.position.y;
        if (playerHeightRelativeToMinimap >= 15)
        {
            minimapCamera.GetComponent<CameraScroll>().AlertCamera(rb.velocity.y, playerHeightRelativeToMinimap);
        }
        #endregion

        #region Boost
        if (BoostCooldown >= 5 && fuel >= 5)
        {
            fuel -= 5;
            float mx, my;
            mx = Mathf.Abs(transform.up.x);
            my = Mathf.Abs(transform.up.y);
            this.rb.velocity = transform.up * GameController.TerminalVelocity / Mathf.Max(mx, my);
        }

        if (BoostCooldown > 0)
        {
            BoostCooldown -= Time.fixedDeltaTime;
        }
        #endregion

        #region Shooting
        if (attackSpeed > 0)
        {
            attackSpeed -= Time.fixedDeltaTime;
        }
        else
        {
            if (isShooting)
            {
                weapon.Shoot();
                attackSpeed = 1.0f;
            }
        }
        #endregion
    }
}
