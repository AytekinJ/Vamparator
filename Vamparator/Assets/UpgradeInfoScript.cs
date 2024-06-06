using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UpgradeInfoScript : MonoBehaviour
{
    public TMP_Text UpgradeText1;
    public TMP_Text UpgradeText2;
    public TMP_Text UpgradeText3;

    public Button UpgradeBtn1;
    public Button UpgradeBtn2;
    public Button UpgradeBtn3;

    public string Upgrade1InfoText;
    public string Upgrade2InfoText;
    public string Upgrade3InfoText;

    public EnemyMeleeAttack meleeAttackScript;
    public EnemySpawn enemySpawnScript;
    public CircleCollider2D KANCOLLIDERI;
    public PlayerBloodEvents playerBloodEventsScript;
    public CollectableFollow collectableFollowScript;

    public void RandomizeValues()
    {
        SetByNumbers(UpgradeBtn1, UpgradeText1, Random.Range(1, 4));
        SetByNumbers(UpgradeBtn2, UpgradeText2, Random.Range(1, 4));
        SetByNumbers(UpgradeBtn3, UpgradeText3, Random.Range(1, 4));
    }

    void SetByNumbers(Button button, TMP_Text text, int number)
    {
        button.onClick.RemoveAllListeners();

        if (number == 1)
        {
            button.onClick.AddListener(Common);
            text.text = Upgrade1InfoText;
        }
        else if (number == 2)
        {
            button.onClick.AddListener(Rare);
            text.text = Upgrade2InfoText;
        }
        else if (number == 3)
        {
            button.onClick.AddListener(Epic);
            text.text = Upgrade3InfoText;
        }
    }


    void Common()
    {
        UpgradefireRate(1.5f);
        UpgradeDamage(1.5f);
        UpgradeMermiMenzil(1.5f);
        UpgradeToplamaMenzil(1.25f);
        UpgradeKanArtisHizi(1.25f);
        Debug.Log("Common");
    }

    void Rare()
    {

        Debug.Log("Rare");
    }

    void Epic()
    {

        Debug.Log("Epic");
    }


    void UpgradefireRate(float MultiplicationValue)
    {
        meleeAttackScript.shootDelay = meleeAttackScript.shootDelay - (meleeAttackScript.shootDelay * MultiplicationValue) / 100;
    }

    void UpgradeDamage(float MultiplicationValue)
    {
        enemySpawnScript.PlayerDamage = enemySpawnScript.PlayerDamage - (enemySpawnScript.PlayerDamage * MultiplicationValue) / 100;
    }

    void UpgradeMermiMenzil(float MultiplicationValue)
    {
        meleeAttackScript.MaxDistance = meleeAttackScript.MaxDistance - (meleeAttackScript.MaxDistance * MultiplicationValue) / 100;
    }

    void UpgradeToplamaMenzil(float MultiplicationValue)
    {
        KANCOLLIDERI.radius = KANCOLLIDERI.radius - (KANCOLLIDERI.radius * MultiplicationValue) / 100;
    }

    void UpgradeKanArtisHizi(float MultiplicationValue)
    {
        collectableFollowScript.healMultipler = collectableFollowScript.healMultipler - (collectableFollowScript.healMultipler * MultiplicationValue) / 100;
    }
}
