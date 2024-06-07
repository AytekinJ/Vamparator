using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeInfoScript : MonoBehaviour
{
    [SerializeField] public Text UpgradeText1;
    [SerializeField] public Text UpgradeText2;

    [SerializeField] public Button UpgradeBtn1;
    [SerializeField] public Button UpgradeBtn2;

    [SerializeField] public Image UpgradeImage1;
    [SerializeField] public Image UpgradeImage2;

    [SerializeField] public string Upgrade1InfoText;
    [SerializeField] public string Upgrade2InfoText;

    [SerializeField] public EnemyMeleeAttack meleeAttackScript;
    [SerializeField] public EnemySpawn enemySpawnScript;
    [SerializeField] public CircleCollider2D KANCOLLIDERI;
    [SerializeField] public PlayerBloodEvents playerBloodEventsScript;
    [SerializeField] public CollectableFollow collectableFollowScript;

    [SerializeField] public Sprite commonDamage;
    [SerializeField] public Sprite commonFireRate;
    [SerializeField] public Sprite commonBlood;
    [SerializeField] public Sprite commonRange;
    [SerializeField] public Sprite commonPickupRange;
    [SerializeField] public Sprite rareDamage;
    [SerializeField] public Sprite rareFireRate;
    [SerializeField] public Sprite rareBlood;
    [SerializeField] public Sprite rareRange;
    [SerializeField] public Sprite rarePickupRange;

    private Sprite[] rare;
    private Sprite[] common;

    private void Awake()
    {
        rare = new Sprite[] { rareDamage, rareFireRate, rareBlood, rareRange, rarePickupRange };
        common = new Sprite[] { commonDamage, commonFireRate, commonBlood, commonRange, commonPickupRange };
        collectableFollowScript.healMultipler = 3;
        KANCOLLIDERI.radius = 1;
    }

    public void RandomizeValues()
    {
        SetByNumbers(UpgradeBtn1, UpgradeText1, UpgradeImage1, Random.Range(1, 5), Random.Range(0, 5));
        SetByNumbers(UpgradeBtn2, UpgradeText2, UpgradeImage2, Random.Range(1, 5), Random.Range(0, 5));
    }

    void SetByNumbers(Button button, Text text, Image image, int number, int spriteNumber)
    {
        if (button == null)
        {
            Debug.LogError("Button is null");
            return;
        }

        if (text == null)
        {
            Debug.LogError("Text is null");
            return;
        }

        if (image == null)
        {
            Debug.LogError("Image is null");
            return;
        }

        button.onClick.RemoveAllListeners();

        if (number == 1)
        {
            text.text = Upgrade1InfoText;
            image.sprite = common[spriteNumber];
            button.onClick.AddListener(() => Common(common[spriteNumber]));
        }
        else if (number == 2)
        {
            text.text = Upgrade2InfoText;
            image.sprite = rare[spriteNumber];
            button.onClick.AddListener(() => Rare(rare[spriteNumber]));
        }
    }

    void Common(Sprite sprite)
    {
        if (sprite == commonDamage)
        {
            UpgradeDamage(4f);
        }
        else if (sprite == commonFireRate)
        {
            UpgradefireRate(0.2f);
        }
        else if (sprite == commonBlood)
        {
            UpgradeKanArtisHizi(0.5f);
        }
        else if (sprite == commonRange)
        {
            UpgradeMermiMenzil(1.5f);
        }
        else if (sprite == commonPickupRange)
        {
            UpgradeToplamaMenzil(1f);
        }
    }

    void Rare(Sprite sprite)
    {
        if (sprite == rareDamage)
        {
            UpgradeDamage(7f);
        }
        else if (sprite == rareFireRate)
        {
            UpgradefireRate(0.3f);
        }
        else if (sprite == rareBlood)
        {
            UpgradeKanArtisHizi(1f);
        }
        else if (sprite == rareRange)
        {
            UpgradeMermiMenzil(3f);
        }
        else if (sprite == rarePickupRange)
        {
            UpgradeToplamaMenzil(2f);
        }

    }

    void UpgradefireRate(float MultiplicationValue)
    {
        if ((meleeAttackScript.shootDelay - MultiplicationValue) < 0.2f)
        {
            meleeAttackScript.shootDelay = 0.2f;
            return;
        }
        else
        meleeAttackScript.shootDelay -= MultiplicationValue;
    }

    void UpgradeDamage(float MultiplicationValue)
    {
        enemySpawnScript.PlayerDamage += MultiplicationValue;
    }

    void UpgradeMermiMenzil(float MultiplicationValue)
    {
        meleeAttackScript.MaxDistance += MultiplicationValue;
    }

    void UpgradeToplamaMenzil(float MultiplicationValue)
    {
        KANCOLLIDERI.radius += MultiplicationValue;
    }

    void UpgradeKanArtisHizi(float MultiplicationValue)
    {
        collectableFollowScript.healMultipler += MultiplicationValue;
    }
}
