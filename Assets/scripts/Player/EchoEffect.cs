using System.Collections;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    [SerializeField] private float startTimeBtwSpawns;

    [SerializeField] EvadeEffectObj echo;
	private CustomPool<EvadeEffectObj> _customPool;
    

	private void Start()
	{
		_customPool = new CustomPool<EvadeEffectObj>(echo, 10);
	}

	public void StartEcho()
	{
		
		StartCoroutine("Echo");
		
	}

	IEnumerator Echo()
	{
		for (int i = 0; i < 10; i++) {
			

			_customPool.Get();
			yield return new WaitForFixedUpdate();
		}

	}

	public void CallRelease(EvadeEffectObj obj)
	{
		_customPool.Release(obj);
	}
}
