using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UpgradeInfoScript : MonoBehaviour
{
    public Text UpgradeText1;
    public Text UpgradeText2;
    public Text UpgradeText3;

    public Button UpgradeBtn1;
    public Button UpgradeBtn2;
    public Button UpgradeBtn3;

    public string Upgrade1InfoText;
    public string Upgrade2InfoText;
    public string Upgrade3InfoText;

    public void RandomizeValues()
    {
        UpgradeText1.text = SetByNumbers(Random.Range(1, 4));
        UpgradeText2.text = SetByNumbers(Random.Range(1, 4));
        UpgradeText3.text = SetByNumbers(Random.Range(1, 4));

    }

    string SetByNumbers(int number)
    {
        if (number == 1)
        {
            return Upgrade1InfoText;
        }
        else if (number == 2)
        {
            return Upgrade2InfoText;
        }
        else if (number == 3)
        {
            return Upgrade3InfoText;
        }
        return string.Empty;
    }
}
