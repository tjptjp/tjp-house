
using System.Collections.Generic;

using System;

public interface Ivaitor
{
	void Update();
}
public class vaitor<T>:Ivaitor
{
	public T value;
	public Func<T> vaitorban{ get; }
	public Action action{ get; }
	public vaitor(Func<T> func,Action ac)
	{
		vaitorban=func;
		action=ac;
	}
	public void Update() 
	{
		var getValue = vaitorban();
		if((value==null&&getValue==null)||(value != null &&value.Equals(vaitorban())))
		{}else
		{
			value=vaitorban();
			action();
		}	
	}
}
