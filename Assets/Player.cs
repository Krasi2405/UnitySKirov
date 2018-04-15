using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;   

public class Player : BaseObject
{

    [SerializeField] private Sprite playerLeftSprite;
    [SerializeField] private Sprite playerRightSprite;
    [SerializeField] private Sprite playerUpSprite;
    [SerializeField] private Sprite playerDownSprite;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Sprite directionSprite;


    protected override void Update()
    {

        base.Update();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Move(horizontal, vertical);
        }

        if (Input.GetButton("Fire1"))
        {
            SpinAttack();
        }
        if (Input.GetButton("Fire2"))
        {
            BasicAttack(horizontal, vertical);
        }
        if (Input.GetButton("Fire3"))
        {
            CastFirstSpell();
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
 

        }

        else if (other.tag == "spell")
        {

        }


        else if (other.tag == "item")
        {

        }
    }

    protected override void SpinAttack()
    {
        RaycastHit2D[] results;
        Vector2 origin = transform.position;
        results = Physics2D.CircleCastAll(origin, spinAttackRange, origin);

        foreach (RaycastHit2D result in results)
        {
            if (result.transform.tag == "enemy")
            {
                // play spinAttack animation
                //var enemyScript = result.transform.GetComponent<Enemy>()
                //enemyScript.TakeHit(damage);
            }
        }
    }
    protected override void BasicAttack(float xDir, float yDir)
    {
        Vector2 start = transform.position;
        int x = Mathf.CeilToInt(xDir);
        int y = Mathf.CeilToInt(yDir);

        Vector2 end = start + new Vector2(x * basicAttackRange, y * basicAttackRange);
        RaycastHit2D result = Physics2D.Linecast(start, end);
        if(result.transform.tag == "enemy")
        {
            // play basicAttack animation
            //var enemyScript = result.transform.GetComponent<Enemy>()
            //enemyScript.TakeHit(damage);
        }
    }
}
