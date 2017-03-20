package mono.com.hitomi.cmlibrary;


public class OnMenuStatusChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.hitomi.cmlibrary.OnMenuStatusChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMenuClosed:()V:GetOnMenuClosedHandler:Com.Hitomi.Cmlibrary.IOnMenuStatusChangeListenerInvoker, CircleMenu\n" +
			"n_onMenuOpened:()V:GetOnMenuOpenedHandler:Com.Hitomi.Cmlibrary.IOnMenuStatusChangeListenerInvoker, CircleMenu\n" +
			"";
		mono.android.Runtime.register ("Com.Hitomi.Cmlibrary.IOnMenuStatusChangeListenerImplementor, CircleMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OnMenuStatusChangeListenerImplementor.class, __md_methods);
	}


	public OnMenuStatusChangeListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == OnMenuStatusChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Hitomi.Cmlibrary.IOnMenuStatusChangeListenerImplementor, CircleMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onMenuClosed ()
	{
		n_onMenuClosed ();
	}

	private native void n_onMenuClosed ();


	public void onMenuOpened ()
	{
		n_onMenuOpened ();
	}

	private native void n_onMenuOpened ();

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
