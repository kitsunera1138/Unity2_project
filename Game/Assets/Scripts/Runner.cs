using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Net.WebRequestMethods;

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
    [SerializeField] Rigidbody rigidbody;

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        OnKeyUpdate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rigidbody.position = new Vector3((int)roadLine * positionX, 0, 0);
    }

    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RoadLine.LEFT)
            {
                roadLine--;
                //FixedUpdate·Î º¯°æ
                //rigidbody.transform.Translate(-positionX, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RoadLine.RIGHT)
            {
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

        StartCoroutine(Attack(isAttack));
    }

    IEnumerator Attack(bool isAttack)
    {
        if(isAttack == false)
        {
            isAttack = true;
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(3f);
            isAttack = false;
        }

    }
}
