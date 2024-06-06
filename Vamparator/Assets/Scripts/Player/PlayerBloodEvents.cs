using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBloodEvents : MonoBehaviour
{
    [SerializeField] float bloodAmount = 50; // Max 100
    [SerializeField] Image blood;
    [SerializeField] float decreaseAmount = 5;
    [SerializeField] public float decreaseRate = 0.5f;
    [SerializeField] Animation healingFadeAnim;
    [SerializeField] Animation RecieveDamageAnim;
    [SerializeField] PlayerMovement movement;
    [SerializeField] EnemyMeleeAttack attack;
    [SerializeField] GameObject dyingImage;
    [SerializeField] GameObject restartButton;
    private bool _isWorking = false;

    void Update()
    {
        blood.fillAmount = bloodAmount/100;
        if (!_isWorking)
        {
            StartCoroutine(bloodDecrease());
        }
    }

    public void decrease(float decreaseAmount)
    {
        if ((bloodAmount -= decreaseAmount) < 0)
        {
            bloodAmount = 0;
            StartCoroutine(Dying());
        }
        else
        {
            bloodAmount -= decreaseAmount;
        }
        RecieveDamageAnim.Play();
    }

    public void increase(float increaseAmount)
    {
        if ((bloodAmount+=increaseAmount) > 100)
        {
            bloodAmount = 100;
        }
        else
        {
            bloodAmount += increaseAmount;
        }
        healingFadeAnim.Play();
    }

    IEnumerator bloodDecrease()
    {
        _isWorking = true;
        if (bloodAmount > 0)
        {
            bloodAmount -= decreaseAmount;
        }
        yield return new WaitForSeconds(decreaseRate);
        _isWorking=false;
    }
    IEnumerator Dying()
    {
        dyingImage.SetActive(true);
        attack.enabled = false;
        movement.CharacterSpeed = 0;
        yield return new WaitForSeconds(2.5f);
        restartButton.SetActive(true);
    }
}
