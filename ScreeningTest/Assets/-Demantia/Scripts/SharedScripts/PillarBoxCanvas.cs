using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PillarBoxCanvas : MonoBehaviour
{
	public Transform PanelCenterPosition, PanelTopPosition, PanelBottomPosition, PanelLeftPosition, PanelRightPosition;
	public GameObject TouchBlocker;

	/// <summary>
	/// 주의 : StartCoroutine으로 호출
	/// </summary>
	public IEnumerator PanelAnimationCoroutine(GameObject Panel, Transform StartPosition, Transform EndPosition)
	{
		TouchBlocker.SetActive(true);
		bool IsFadeIn = EndPosition == PanelCenterPosition;
		if (IsFadeIn) Panel.SetActive(true);
		Panel.transform.position = StartPosition.position;
		yield return Panel.transform.DOMove(EndPosition.position, 0.4f).SetEase(Ease.OutCirc).SetUpdate(true).WaitForCompletion();
		if (!IsFadeIn) Panel.SetActive(false);
		TouchBlocker.SetActive(false);
	}
}
