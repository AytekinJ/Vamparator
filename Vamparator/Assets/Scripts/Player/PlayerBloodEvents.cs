using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBloodEvents : MonoBehaviour
{
    [SerializeField] public float bloodAmount = 50; // Max 100
    [SerializeField] Image blood;
    [SerializeField] float decreaseAmount = 5;
    [SerializeField] public float decreaseRate = 0.5f;
    [SerializeField] Animation healingFadeAnim;
    [SerializeField] Animation RecieveDamageAnim;
    [SerializeField] PlayerMovement movement;
    [SerializeField] EnemyMeleeAttack attack;
    [SerializeField] GameObject dyingImage;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject upgradePage;
    [SerializeField] EnemySpawn es;
    [SerializeField] GameObject joystik;

    Animator animator;
    private bool _isWorking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
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
        else
        {
            StartCoroutine(Dying());
        }
        yield return new WaitForSeconds(decreaseRate);
        _isWorking=false;
    }
    IEnumerator Dying()
    {
        es.isDied = true;
        joystik.SetActive(false);
        animator.SetBool("isDead", true);
        movement.CharacterSpeed = 0;
        upgradePage.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        dyingImage.SetActive(true);
        attack.enabled = false;
        yield return new WaitForSeconds(2.5f);
        restartButton.SetActive(true);
    }
}
