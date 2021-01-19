﻿using UnityEngine;
using Invector.vCharacterController;
public class Player : MonoBehaviour
{
    private float hp = 100;
    private Animator ani;

    private int atkCount;

    private float timer;
    [Header("連擊間隔"), Range(0, 3)]
    public float interval = 2;
    [Header("攻擊中心點")]
    public Transform point;
    [Header("攻擊長度"), Range(0f, 5f)]
    public float attacklength;
    [Header("攻擊力"), Range(0, 500)]
    public float atk = 30;
    

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        Attack();
    }

    private RaycastHit hit;
    private void Attack()
    {
        if(atkCount<4)
        {
            if (timer < interval)
            {
                timer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    atkCount++;
                    timer = 0;
                    if (Physics.Raycast(point.position, point.forward, out hit, attacklength, 1 << 9))
                    {
                        hit.collider.GetComponent<Enemy>().Damage(atk);
                    }
                }
            }
            else
            {
                atkCount = 0;
                timer = 0;
            }
        }
       
        if (atkCount == 4) atkCount = 0;
        ani.SetInteger("連擊", atkCount);
    }
        
        

public void Damage(float damage)
    {
        hp -= damage;
        ani.SetTrigger("受傷觸發");

        if (hp <= 0) Dead();

    }

    private void Dead()
    {
        ani.SetTrigger("死亡觸發");
        vThirdPersonController vt =  GetComponent<vThirdPersonController>();
        vt.lockMovement = true;
        vt.lockRotation = true;
    }    
     private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(point.position, point.forward * attacklength);
    }
    }
   