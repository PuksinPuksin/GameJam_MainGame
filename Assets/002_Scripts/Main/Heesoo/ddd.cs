using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Utill
{
    public static class Dotween
    {
        /// <summary>
        /// 중앙에서 원 모양으로 퍼지는 애니메이션
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static Sequence PopUpAnimation(GameObject gameObject)
        {
            return DOTween.Sequence()
           .SetAutoKill(false)
           .AppendCallback(() =>
           {
               gameObject.SetActive(true);
           })
           .OnStart(() =>
           {
               gameObject.transform.localScale = Vector3.zero;
           })
           .Append(gameObject.transform.DOScale(1, 0.3f).SetEase(Ease.InCirc))
           .SetDelay(0.1f)
           .SetUpdate(true);

        }
    }

}