package mono.com.hitomi.cmlibrary;


public class OnMenuSelectedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.hitomi.cmlibrary.OnMenuSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMenuSelected:(I)V:GetOnMenuSelected_IHandler:Com.Hitomi.Cmlibrary.IOnMenuSelectedListenerInvoker, CircleMenu\n" +
			"";
		mono.android.Runtime.register ("Com.Hitomi.Cmlibrary.IOnMenuSelectedListenerImplementor, CircleMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OnMenuSelectedListenerImplementor.class, __md_methods);
	}


	public OnMenuSelectedListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == OnMenuSelectedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Hitomi.Cmlibrary.IOnMenuSelectedListenerImplementor, CircleMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onMenuSelected (int p0)
	{
		n_onMenuSelected (p0);
	}

	private native void n_onMenuSelected (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
