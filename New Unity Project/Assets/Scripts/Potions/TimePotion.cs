using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;

public class TimePotion : MonoBehaviour
{
    [SerializeField] private float timeModifier = .5f;
    [SerializeField] private int timeToLast = 5;

    private void OnCollisionEnter2D(Collision2D other)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.clear;
        StartCoroutine(PotionCountDown(timeToLast));
    }

    private IEnumerator PotionCountDown(int seconds)
    {
        int time = seconds;
        while (time >= 0)
        {
            Time.timeScale = timeModifier;
            Destroy(gameObject, timeToLast * 2);
            yield return new WaitForSeconds(1);
            time--;
        }

        Time.timeScale = 1;
    }
}