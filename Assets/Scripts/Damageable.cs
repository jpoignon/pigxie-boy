using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private int _maxHealth = 100;
    public int MaxHeath 
    { 
        get 
        {
            return _maxHealth;    
        }
        set 
        { 
            _maxHealth = value;
        } 
    }

    [SerializeField]
    private int _health = 100;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;

            // If health is less than or equal to 0, set IsAlive to false
            if (_health <= 0) 
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;
    [SerializeField]
    private bool isInvincible = false;
    private float timeSinceHit = 0;
    private float invincibilityTime = 0.25f;

    public bool IsAlive 
    { 
        get 
        { 
            return _isAlive; 
        }
        set 
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set to: " + value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();       
    }

    private void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                // Remove invincibility
                isInvincible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
        }
    }

    public void Hit(int damage) 
    {
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;
        }
    }
}
