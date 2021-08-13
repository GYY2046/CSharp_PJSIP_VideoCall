//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class UaConfig : PersistentObject {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal UaConfig(global::System.IntPtr cPtr, bool cMemoryOwn) : base(pjsua2PINVOKE.UaConfig_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(UaConfig obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  protected override void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          pjsua2PINVOKE.delete_UaConfig(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      base.Dispose(disposing);
    }
  }

  public uint maxCalls {
    set {
      pjsua2PINVOKE.UaConfig_maxCalls_set(swigCPtr, value);
    } 
    get {
      uint ret = pjsua2PINVOKE.UaConfig_maxCalls_get(swigCPtr);
      return ret;
    } 
  }

  public uint threadCnt {
    set {
      pjsua2PINVOKE.UaConfig_threadCnt_set(swigCPtr, value);
    } 
    get {
      uint ret = pjsua2PINVOKE.UaConfig_threadCnt_get(swigCPtr);
      return ret;
    } 
  }

  public bool mainThreadOnly {
    set {
      pjsua2PINVOKE.UaConfig_mainThreadOnly_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.UaConfig_mainThreadOnly_get(swigCPtr);
      return ret;
    } 
  }

  public StringVector nameserver {
    set {
      pjsua2PINVOKE.UaConfig_nameserver_set(swigCPtr, StringVector.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.UaConfig_nameserver_get(swigCPtr);
      StringVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new StringVector(cPtr, false);
      return ret;
    } 
  }

  public StringVector outboundProxies {
    set {
      pjsua2PINVOKE.UaConfig_outboundProxies_set(swigCPtr, StringVector.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.UaConfig_outboundProxies_get(swigCPtr);
      StringVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new StringVector(cPtr, false);
      return ret;
    } 
  }

  public string userAgent {
    set {
      pjsua2PINVOKE.UaConfig_userAgent_set(swigCPtr, value);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      string ret = pjsua2PINVOKE.UaConfig_userAgent_get(swigCPtr);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public StringVector stunServer {
    set {
      pjsua2PINVOKE.UaConfig_stunServer_set(swigCPtr, StringVector.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.UaConfig_stunServer_get(swigCPtr);
      StringVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new StringVector(cPtr, false);
      return ret;
    } 
  }

  public bool stunTryIpv6 {
    set {
      pjsua2PINVOKE.UaConfig_stunTryIpv6_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.UaConfig_stunTryIpv6_get(swigCPtr);
      return ret;
    } 
  }

  public bool stunIgnoreFailure {
    set {
      pjsua2PINVOKE.UaConfig_stunIgnoreFailure_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.UaConfig_stunIgnoreFailure_get(swigCPtr);
      return ret;
    } 
  }

  public int natTypeInSdp {
    set {
      pjsua2PINVOKE.UaConfig_natTypeInSdp_set(swigCPtr, value);
    } 
    get {
      int ret = pjsua2PINVOKE.UaConfig_natTypeInSdp_get(swigCPtr);
      return ret;
    } 
  }

  public bool mwiUnsolicitedEnabled {
    set {
      pjsua2PINVOKE.UaConfig_mwiUnsolicitedEnabled_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.UaConfig_mwiUnsolicitedEnabled_get(swigCPtr);
      return ret;
    } 
  }

  public UaConfig() : this(pjsua2PINVOKE.new_UaConfig(), true) {
  }

  public override void readObject(ContainerNode node) {
    pjsua2PINVOKE.UaConfig_readObject(swigCPtr, ContainerNode.getCPtr(node));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public override void writeObject(ContainerNode node) {
    pjsua2PINVOKE.UaConfig_writeObject(swigCPtr, ContainerNode.getCPtr(node));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

}
