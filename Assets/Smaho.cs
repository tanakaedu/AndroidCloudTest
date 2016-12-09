using UnityEngine;
using System.Collections;

public class Smaho : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 ac = Input.acceleration;
		//* Landscape Leftの時
		//
		// (0,0,-1)=画面真上
		//	(0,0,1)=画面真下
		//	(0,-1,0)=画面が手前90度
		//	(0,1,0)=画面が奥90度
		//	(-1,0,0)=画面を左に90度
		//	(1,0,0)=画面を右に90度
		//
		// Quaternion.Eular(x軸角度,Y軸角度,Z軸角度)
		//
		// accelerationは重力加速度の方向なので、
		// 回転ではないが、今回は暫定的に回転として利用する。
		//
		// acceleration.xは、横の回転、つまり、Z軸回転
		//
		Vector3 euler = Vector3.zero;
		euler.z = -Input.acceleration.x * 60f;

		// acceleration.yは、前後の回転、つまり、X軸回転
		euler.x = Input.acceleration.y*60f;

		// 求めたオイラー角を反映させる
		transform.rotation = Quaternion.Euler (euler);
	}

	void OnGUI() {
		GUI.Label (new Rect (0, 0, 100, 30), "" + Input.acceleration.x);
		GUI.Label (new Rect (0, 20, 100, 30), "" + Input.acceleration.y);
		GUI.Label (new Rect (0, 40, 100, 30), "" + Input.acceleration.z);
	}
}
