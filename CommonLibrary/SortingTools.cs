using System.Collections.Generic;
using UnityEngine;

namespace CommonSouzM.SouzMCore.Common.Lib.Extensions
{
    public class SortingTools
    {
        public static void SortingTilesForBetterVisuals<T>(List<T> itemTilesForLoading) where T : MonoBehaviour
        {
            Vector2 screenCenter = new Vector2(0.5f * Screen.width, 0.5f * Screen.height);
            Vector2 screenAspect = new Vector2((float) Screen.height / (float) Screen.width, 1);

            //Sorting for better visuals
            itemTilesForLoading.Sort(delegate(T a, T b)
            {
                Vector2 positionA = RectTransformUtility.WorldToScreenPoint(null, a.transform.position) - screenCenter;
                Vector2 positionB = RectTransformUtility.WorldToScreenPoint(null, b.transform.position) - screenCenter;

                positionA.Scale(screenAspect);
                positionB.Scale(screenAspect);

                float distanceToScreenCenterA = Vector2.Distance(positionA, Vector2.zero);
                float distanceToScreenCenterB = Vector2.Distance(positionB, Vector2.zero);
                return distanceToScreenCenterA.CompareTo(distanceToScreenCenterB);
            });
        }
    }
}