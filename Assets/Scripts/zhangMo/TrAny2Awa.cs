﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrAny2Awa : FSMTransition {

	public TrAny2Awa(FSMstate nowState):base(nowState){ }

	public override bool isValid()
	{
		if(data.chaseTarget != null || data.isTimeToEnterAware)
		{
			//Debug.Log("go to aware");
			return true;
		}
		return false;
	}

	public override void onTransition()
	{
		FSMAware newState = new FSMAware(activeState.getEnemyObject());
		SetNextState(newState);
		data.isTimeToEnterAware = false;
	}
}
