using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;
using TMPro;

public class GravityPotion : MonoBehaviour
{
    [SerializeField] private float gravityModifier = 1.5f;
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
        controller.jumpTakeOffSpeed *= gravityModifier;
        while (time > 0)
        {
            _textMeshProUGUI.text = "" + time;
            Destroy(gameObject, timeToLast * 2);
            yield return new WaitForSeconds(1);
            time--;
        }

        _textMeshProUGUI.text = "0";
        controller.jumpTakeOffSpeed /= gravityModifier;
    }
}