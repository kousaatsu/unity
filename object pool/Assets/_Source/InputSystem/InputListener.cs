using System;
using ShootingSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private CharacterShooter characterShooter;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                characterShooter.Shoot();
            }
        }
    }
}
