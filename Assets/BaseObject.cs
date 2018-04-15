using UnityEngine;
using System.Collections;
using System;

public abstract class BaseObject : MonoBehaviour
{
    public float moveSpeed = 10f;
    public int hp = 100;
    public float damage = 10f;
    [Range(0, 100)] public float armor = 5f;
    public float missChance = 0.1f;
    public int spinAttackRange = 10;
    public int basicAttackRange = 10;
    public float firstSpellCooldown = 5f;
    public float secondSpellCooldown = 5f;
    public float thirdSpellCooldown = 5f;

    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Sprite directionSprite;
    private float firstSpellCounter = 0f;
    private float secondSpellCounter = 0f;
    private float thirdSpellCounter = 0f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        directionSprite = downSprite;
    }
    protected virtual void Update()
    {
        firstSpellCounter += Time.deltaTime;
        secondSpellCounter += Time.deltaTime;
        thirdSpellCounter += Time.deltaTime;
    }

    //Move returns true if it is able to move and false if not. 
    protected virtual void Move(float rawHorizontal, float rawVertical)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(rawHorizontal, rawVertical);
        Vector2 newPosition = Vector2.MoveTowards(start, end, moveSpeed * Time.deltaTime);

        rb2D.MovePosition(newPosition);

        animator.SetBool("isWalkingDown", false);
        animator.SetBool("isWalkingUp", false);
        animator.SetBool("isWalkingLeft", false);
        animator.SetBool("isWalkingRight", false);
        if (rawHorizontal > 0 && rawHorizontal >= rawVertical) // right
        {
            animator.SetBool("isWalkingRight", true);
            directionSprite = rightSprite;
        }
        else if (rawHorizontal < 0 && rawHorizontal <= rawVertical) // left
        {

            animator.SetBool("isWalkingLeft", true);
            directionSprite = leftSprite;
        }
        else if (rawVertical > 0 && rawVertical > rawHorizontal) // up
        {
            animator.SetBool("isWalkingUp", true);
            directionSprite = upSprite;

        }
        else if (rawVertical < 0 && rawVertical < rawHorizontal) // down
        {
            animator.SetBool("isWalkingDown", true);
            directionSprite = downSprite;

        }
        ChangeSprite();

    }

    private void ChangeSprite()
    {
        spriteRenderer.sprite = directionSprite;
    }

    protected abstract void SpinAttack();

    protected abstract void BasicAttack(float xDir, float yDir);

    protected virtual void CastFirstSpell()
    {
        if(firstSpellCounter >= firstSpellCooldown)
        {
            //instantiate spell and give it velocity
            firstSpellCounter = 0;
        }
    } 

    protected virtual void TakeHit(float ammount)
    {

        if (UnityEngine.Random.Range(0, 1) > missChance)
        {
            float loss = ammount - (armor % 100);
            hp = hp - (int)loss;
        }

    }


}