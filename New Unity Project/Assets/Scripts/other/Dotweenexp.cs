using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;
public static class Dotweenexp  
{
	public static Tweener DoSetsize(this FairyGUI.GObject target, Vector2 endValue, float duration)
	{
		return DOTween.To(() =>
			{
				return target.size;
			},
			(Vector2 val) =>
			{
			target.SetSize(val.x,val.y);
			}, endValue, duration);
	}
	public static Tweener DoSetsizex(this FairyGUI.GObject target, float endValue, float duration)
	{
		return DOTween.To(() =>
			{
				return target.x;
			},
			(float val) =>
			{
			target.x=val;
			}, endValue, duration);
	}
	public static Tweener Doscale(this FairyGUI.GObject target, Vector2 endValue, float duration)
	{
		return DOTween.To(() =>
			{
				return target.scale;
			},
			(Vector2 val) =>
			{
			target.SetScale(val.x,val.y);
			}, endValue, duration);
	}
	public static Tweener DoVsible(this FairyGUI.GObject target, float endValue, float duration)
	{
		return DOTween.To(() =>
			{
				return target.alpha;
			},
			(float val) =>
			{
			target.alpha=val;
			}, endValue, duration);
	}

}
