using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadGuy : MonoBehaviour
{
    public float startHealth = 100;
    private float health;
    public Image healthBar;
    public int moneyWorth;
    public int scoreWorth;
    public GameObject moneyUI;
    public GameObject scoreUI;
    Animator animator;
    Collider m_Collider;
    private int wayPointIndex = 0;
    private Transform target;
    public float speed = 0.3f;
    public bool isAttacking = false;
    private Vector3 towerCenter = new Vector3(0f, 0f, 0f);

    private Transform currPos;

    void Start()
    {
        target = WayPoints.points[1];
        health = startHealth;
        animator = this.GetComponent<Animator>();
        m_Collider = GetComponent<Collider>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    void Update()
    {
        if (!isAttacking)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.5f)
            {
                GetNextWayPoint();
            }
        }
    }
    void GetNextWayPoint()
    {
        if (wayPointIndex == WayPoints.points.Length - 2 || wayPointIndex == WayPoints.points.Length - 4)
        {
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        }
        else
        if (wayPointIndex == WayPoints.points.Length - 3)
        {
            transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
        }

        if (wayPointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }

    void Die()
    {
        Destroy(gameObject);
        Currency.Money += moneyWorth;

        var _moneyUI = moneyUI.GetComponent<MoneyUI>();
        _moneyUI.KilledEnemies(moneyWorth);

        Score.score += scoreWorth;
        var _scoreUI = scoreUI.GetComponent<ScoreUI>();
        _scoreUI.KilledEnemies(scoreWorth);

    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("coll with friendly soldier");

        if (collider.tag == "friendly_soldier")
        {
            isAttacking = true;
            m_Collider.enabled = false;
            animator.SetInteger("isAttacking", 1);
        }
    }

    // void FixedUpdate()
    // {
    //     Vector3 dir = towerCenter - transform.position;
    //     this.transform.GetComponent<Rigidbody>().AddForce(dir * speed);
    //     // rb.MovePosition(Vector3.zero);
    // }
}
