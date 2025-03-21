using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1,
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine = RoadLine.MIDDLE;

    [SerializeField] int positionX = 4;
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputManager.Instance.action += OnKeyUpdate;
    }

    void Update()
    {
        //OnKeyUpdate();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.State == false) { return; }
        Move();
    }


    void Move()
    {
        //rigidbody.position = new Vector3((int)roadLine * positionX, 0, 0);


        //선형 보간 방식으로 변경 -> 도착하기 전에 움직이면 위치 오차 생김
        rigidbody.position = Vector3.Lerp(rigidbody.position, new Vector3((int)roadLine * positionX, 0, 0), Time.deltaTime * speed);
    }

    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RoadLine.LEFT)
            {
                animator.Play("Left Avoid");
                roadLine--;
                //FixedUpdate로 변경
                //rigidbody.transform.Translate(-positionX, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RoadLine.RIGHT)
            {
                animator.Play("Right Avoid");
                roadLine++;
                //rigidbody.transform.Translate(positionX, 0, 0);
            }
        }
    }

    //void OnMove(InputValue value)
    //{
    //    Vector2 inputvalue = value.Get<Vector2>();
    //    Debug.Log(inputvalue);
    //}

    bool isAttack = false;
    void OnSpace()
    {
        Debug.Log("Space");

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        if (isAttack == false)
        {
            isAttack = true;
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(3f);
            isAttack = false;
        }

    }


    private void OnDisable()
    {
        InputManager.Instance.action -= OnKeyUpdate;
    }
}
