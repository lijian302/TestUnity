#region 文件信息
/*
 * 文件名:		TestAnimator
 * 作者:			袁剑伟
 * 创建时间:   2019年01月19日 10:25:24
 * 公司:			广州市梦途信息科技有限责任公司
 * Unity版本:   2018.3.0f2
 * 项目名称:    HorrorGallery
 * 描述信息:
 * 
*/
#endregion
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MengTu
{
    public class TestAnimator : MonoBehaviour
    {
        private Animator animator;
        private AnimatorStateInfo stateInfo;
        private bool isComplete;
        private Vector3 previousAngle;
        private Vector3 previousPos;
        private Transform boneTrans;

        // 在这个地方调用
        void Start()
        {
            animator = GetComponent<Animator>();
            boneTrans = animator.transform.Find("Bone001");
        }

        // 每次更新，都要掉用这个方法
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("IsRound");
            }

            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Round") && stateInfo.normalizedTime >= 1)
            {
                animator.Play("Climb");
                previousAngle = boneTrans.eulerAngles;
                previousPos = boneTrans.position;
                isComplete = true;
            }
        }

        private void LateUpdate()
        {
            if (isComplete)
            {
                Vector3 deltaAngle = boneTrans.eulerAngles - previousAngle;
                Debug.Log("deltaAngle: " + deltaAngle);
                animator.transform.parent.eulerAngles -= deltaAngle;
                Vector3 deltaPos = boneTrans.position - previousPos;
                Debug.Log("deltaPos: " + deltaPos);
                animator.transform.parent.position -= deltaPos;
                isComplete = false;
            }
        }
    }
}
