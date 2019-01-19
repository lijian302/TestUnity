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

        // 在这个地方调用
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // 每次更新，都要掉用这个方法
        void Update()
        {
            //Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length + ", "
            //    + animator.GetCurrentAnimatorStateInfo(0).length + ", "
            //    + animator.GetCurrentAnimatorStateInfo(0).normalizedTime + ", "
            //    + animator.GetCurrentAnimatorStateInfo(0).normalizedTime * animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("IsRound");
            }
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Round") && stateInfo.normalizedTime >= 1)
            {
                Debug.Log("complete0" + animator.transform.Find("Bone001").eulerAngles);
                animator.Play("Climb");
                isComplete = true;
                previousAngle = animator.transform.localEulerAngles;
                Debug.Log("complete1" + animator.transform.Find("Bone001").eulerAngles);
            }
        }

        private void LateUpdate()
        {
            if (isComplete)
            {
                Debug.Log("complete2" + animator.transform.Find("Bone001").localEulerAngles);
                animator.transform.localEulerAngles += animator.transform.Find("Bone001").eulerAngles - previousAngle;
                isComplete = false;
            }
        }
    }
}
