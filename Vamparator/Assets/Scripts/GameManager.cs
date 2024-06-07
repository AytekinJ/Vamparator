using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace GM
{
    public class GameManager : MonoBehaviour
    {
        public static int Score = 0;

        public int CurrentNecessaryUpgradeCount = 0;
        public int upgradeNumber = 5;

        int hiddenScore = 0;

        public GameObject UpgradePanel;

        private UpgradeInfoScript _upgradeInfoScript;

        private void Start()
        {
            _upgradeInfoScript = UpgradePanel.GetComponent<UpgradeInfoScript>();
        }

        void Update()
        {
            hiddenScore = Score;
            if (hiddenScore >= CurrentNecessaryUpgradeCount)
            {
                hiddenScore = 0;
                CurrentNecessaryUpgradeCount += upgradeNumber;
                OpenUpgradePage();
            }
        }

        public void OpenUpgradePage()
        {
            UpgradePanel.SetActive(true);
            _upgradeInfoScript.RandomizeValues();
            Time.timeScale = 0f;
        }

        public void CloseUpgradePage()
        {
            UpgradePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
