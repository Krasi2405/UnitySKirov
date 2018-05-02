using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;

    private NPC target;

    public void Update()
    {
        ClickTarget();
    }

    private void ClickTarget()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // check if player is not clickng UI object
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.positiveInfinity);
            if(hit.collider != null)
            {
                if (target != null) {
                    target.Deselect();
                }

                target = hit.collider.GetComponent<NPC>();

                player.target = target.Select();
            }
            else
            {
                if(target != null)
                {
                    target.Deselect();
                }
                target = null;
                player.target = null;
            }
        }
    }


    /*public static GameManager instance = null;

    void Awake()
    {

        if (instance == null)


            instance = this;

        else if (instance != this)


            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    */
}