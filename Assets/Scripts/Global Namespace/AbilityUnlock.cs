using UnityEngine;
using TMPro;
using SaveSystem;

namespace GameManagement
{
    public class AbilityUnlock : MonoBehaviour
    {
        private enum UnlockAbility { DoubleJump, Dash, BecomeDrone, DropBomb };
        [SerializeField] private UnlockAbility unlockOption;
        
        public GameObject pickupEffect;

        public string unlockMessage;
        public TMP_Text unlockText;
        public Transform playerPos;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                UpdateAbilityTracker();
                Saver.SaveNow(new SaveData(other.gameObject.transform));

                Instantiate(pickupEffect, transform.position, transform.rotation);

                unlockText.transform.parent.SetParent(null);
                unlockText.transform.parent.position = transform.position;

                unlockText.text = unlockMessage;
                unlockText.gameObject.SetActive(true);

                Destroy(unlockText.transform.parent.gameObject, 5f);

                Destroy(gameObject);

                AudioManager.instance.PlaySFX(5);
            }
        }

        private void UpdateAbilityTracker()
        {
            switch (unlockOption)
            {
                case UnlockAbility.DoubleJump:
                    PlayerAbilityTracker.SetDoubleJump(true);
                    return;
                case UnlockAbility.Dash:
                    PlayerAbilityTracker.SetDash(true);
                    return;
                case UnlockAbility.BecomeDrone:
                    PlayerAbilityTracker.SetBecomeDrone(true);
                    return;
                case UnlockAbility.DropBomb:
                    PlayerAbilityTracker.SetDropBomb(true);
                    return;
                default:
                    Debug.LogException(new System.NotImplementedException());
                    return;
            }
        }
    }
}