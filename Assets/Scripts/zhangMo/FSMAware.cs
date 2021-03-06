﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAware : FSMstate {
	public FSMAware(GameObject thisGameObj):base(thisGameObj)
	{
		enemyObject = thisGameObj;
	}
	[SerializeField]
	private float speed;
	private Vector3 position;
	private float timer = 0.0f;
	public override void onEnter()
	{
		transitions.Add(new TrAny2Die(this));
		transitions.Add(new TrAwa2Atk(this));
		// 察觉到玩家，在这里输入玩家pos

		// 丢失玩家视野
		transitions.Add(new TrAwa2Con(this));
	}
	public override void onUpdate()
	{

		// 检测玩家是否在影子中
		foreach (var trans in transitions)
		{
			if(trans.isValid())
			{
				validTranstion = trans;
				//Debug.Log(trans.name);
				break;
			}
		}
		if(data.chaseTarget!= null)
		{
			position = data.chaseTarget.position;
			Move(data.chaseTarget.position);
		}
		else
		{
			timer += Time.deltaTime;
			if(timer > data.getPatientTime())
				data.isTimeToQuitAware = true;
			Move(position);
		}
	}

	public override void Move(Vector3 target)
	{
		setSpeed();
		//Debug.Log("move to player");
        //改变敌人的方向
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //if (player.transform.position.x < enemyTrans.position.x)
        //    enemyTrans.localScale = new Vector3(-1, 1, 1);
        //else
        //    enemyTrans.localScale = new Vector3(1, 1, 1);
        //enemyObject.GetComponent<Animator>().SetBool("isMove", true);
        enemyTrans.position = Vector3.MoveTowards(enemyTrans.position,new Vector3(target.x,enemyTrans.position.y,target.z),speed*Time.deltaTime);  
    }
	public override void onExit()
	{
		transitions.Clear();
	}

	public void setSpeed()
	{
		speed = data.getSpeed();
	}
}
