using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBloodEvents : MonoBehaviour
{
    [SerializeField] float bloodAmount = 50; // Max 100
    [SerializeField] Image blood;
    [SerializeField] float decreaseAmount = 5;
    [SerializeField] float decreaseRate = 0.5f;
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
        bloodAmount -= decreaseAmount;
    }
    public void increase(float increaseAmount)
    {
        bloodAmount += increaseAmount;
    }
    IEnumerator bloodDecrease()
    {
        _isWorking = true;
        bloodAmount -= decreaseAmount;
        yield return new WaitForSeconds(decreaseRate);
        _isWorking=false;
    }
}
