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
}
