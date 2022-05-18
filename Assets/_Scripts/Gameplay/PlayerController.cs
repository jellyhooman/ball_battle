using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.PlayerInfo;

public class PlayerController : Singleton<PlayerController>
{
    private string PlayerField = "player_field";
    private string EnemyField = "enemy_field";

    public delegate void DelegateOnClickPlayer();
    public DelegateOnClickPlayer delegateOnClickPlayer;

    public delegate void DelegateOnClickEnemy();
    public DelegateOnClickEnemy delegateOnClickEnemy;

    private void Update() 
    {
        OnClick();
    }

    private void ClickHandler(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log($"RAYCAST: {hit.transform.tag}");
            if (hit.transform.tag == PlayerField)
            {
                delegateOnClickPlayer();
            }
            else if (hit.transform.tag == EnemyField)
            {
                delegateOnClickEnemy();
            }
            
        }
    }

    private void OnClick()
    {
        // #if UNITY_ANDROID
        // Touch[] touches = Input.touches;

        // if (touches.Length > 0)
        // {
        //     Touch touch = touches[0];
        //     if (touch.phase == TouchPhase.Ended)
        //     {
        //         ClickHandler(touch.position);
        //     }
        // }
        // #endif

        // #if UNITY_STANDALONE_WIN
        // if (Input.GetMouseButtonDown(0))
        // {
        //     ClickHandler(Input.mousePosition);
        // }
        // #endif

        Touch[] touches = Input.touches;

        if (touches.Length > 0)
        {
            Touch touch = touches[0];
            if (touch.phase == TouchPhase.Ended)
            {
                ClickHandler(touch.position);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            ClickHandler(Input.mousePosition);
        }
    }
}
