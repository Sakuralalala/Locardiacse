﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMDie : FSMstate {
	public FSMDie(GameObject thisGameObj):base(thisGameObj)
	{
		enemyObject = thisGameObj;
	}
	[SerializeField]
	private float speed;
	public override void onEnter()
	{
		Debug.Log("Enter Die state.");
	}
	public override void onUpdate()
	{
		//TODO 播放死亡动画，然后Destory()
		GameObject.Destroy(enemyObject);
	}
	public override void onExit()
	{

	}
}
