using UnityEngine;
using System.Collections;

public class Money {

	public enum MoneyType{
		Risky,
		Consistent
	}
	public MoneyType Type;
	public int Amount;
	GameObject Card;
}
