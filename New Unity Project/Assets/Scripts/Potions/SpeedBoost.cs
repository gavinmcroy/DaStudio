using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Platformer.Mechanics;
using UnityEngine;
using Object = UnityEngine.Object;
using TMPro;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float speedModifier = 1.5f;
    [SerializeField] private int timeToLast = 5;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    private void OnCollisionEnter2D(Collision2D other)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.clear;
        StartCoroutine(SpeedCountDown(timeToLast, other.gameObject));
    }

    private IEnumerator SpeedCountDown(int seconds, GameObject other)
    {
        int time = seconds;
        PlayerController controller = other.gameObject.GetComponent<PlayerController>();
        controller.maxSpeed *= speedModifier;
        while (time >= 0)
        {
            _textMeshProUGUI.text = "" + time;
            Destroy(gameObject, timeToLast * 2);
            yield return new WaitForSeconds(1);
            time--;
        }

        controller.maxSpeed /= speedModifier;
    }
}