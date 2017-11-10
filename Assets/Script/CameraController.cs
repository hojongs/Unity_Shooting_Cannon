using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script_1
{
    public class CameraController : MonoBehaviour
    {
        public const int ROTATE_SPEED = 100; // 100 -> 카메라 회전속도
        public const int VERTICAL_MAX_ANGLE = 90; // 90 -> 카메라 최대 회전각도
        private Transform objPlayer;
        private Camera objCam;

        // Use this for initialization
        void Start()
        {
            objPlayer = transform.parent;
            Debug.Assert(objPlayer);

            objCam = GetComponent<Camera>();
            Debug.Assert(objCam);
        }

        // Update is called once per frame
        void Update()
        {
            //////////////////////////
            // hide mouse
            //////////////////////////

            // if Ctrl Key Down
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                // hide
                if (Cursor.visible)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else // un-hide
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            } // if ()

            //////////////////////////
            // Rotate Horizontal
            //////////////////////////

            var mX = Input.GetAxis("Mouse X");
            objPlayer.Rotate(0, mX * ROTATE_SPEED * Time.deltaTime, 0, Space.Self);

            //////////////////////////
            // Rotate Vertical
            //////////////////////////

            // 현재 vertical angle 구하기
            var xAngle = objCam.transform.rotation.eulerAngles.x;
            if (180 < xAngle)
                xAngle -= 360;
            // 회전할 vertical angle 구하기
            var mY = Input.GetAxis("Mouse Y") * -1;
            var angle = mY * ROTATE_SPEED * Time.deltaTime;
            if ((0 < mY && (xAngle + angle) < VERTICAL_MAX_ANGLE) ||   // 아래로 회전할 때, 아래로 LIMIT도 이상은 제한
                (mY < 0 && -VERTICAL_MAX_ANGLE < (xAngle + angle)))    // 위로 회전할 때, 위로 LIMIT도 이상은 제한
                objCam.transform.Rotate(angle, 0, 0, Space.Self);
        }
    }
}