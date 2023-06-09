using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Tanks;

namespace Game.UserInput
{
    [RequireComponent(typeof(IBodyControll), typeof(ITowerControll), typeof(IGunControll))]
    public class TankController : MonoBehaviour
    {
        private IBodyControll bodyControll;
        private ITowerControll towerControll;
        private IGunControll gunControll;


        private void Awake()
        {
            bodyControll = GetComponent<IBodyControll>();
            towerControll = GetComponent<ITowerControll>();
            gunControll = GetComponent<IGunControll>();
        }

        private void BodyMovement()
        {
            bodyControll.Drive(Input.GetAxis("Vertical"));
            bodyControll.Turn(Input.GetAxis("Horizontal"));
        }
        private void TowerMovement()
        {
            Vector2 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 1000))
            {
                towerControll.Turn(hit.point);
            }
        }
        private void FireControll()
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                gunControll.Fire();
            }
        }

        private void Update()
        {
            BodyMovement();
            TowerMovement();
            FireControll();
        }
    }
}
