﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrCon2Pat : FSMTransition {

	public TrCon2Pat(FSMstate nowState):base(nowState){ }

	public override bool isValid()
	{
		if(data.isConfusedOver)
		{
			return true;
		}
		return false;
	}

	public override void onTransition()
	{
		FSMPatrol newState = new FSMPatrol(activeState.getEnemyObject());
		SetNextState(newState);
	}

}
