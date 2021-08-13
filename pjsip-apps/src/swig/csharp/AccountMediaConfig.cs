//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class AccountMediaConfig : PersistentObject {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal AccountMediaConfig(global::System.IntPtr cPtr, bool cMemoryOwn) : base(pjsua2PINVOKE.AccountMediaConfig_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AccountMediaConfig obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  protected override void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          pjsua2PINVOKE.delete_AccountMediaConfig(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      base.Dispose(disposing);
    }
  }

  public TransportConfig transportConfig {
    set {
      pjsua2PINVOKE.AccountMediaConfig_transportConfig_set(swigCPtr, TransportConfig.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.AccountMediaConfig_transportConfig_get(swigCPtr);
      TransportConfig ret = (cPtr == global::System.IntPtr.Zero) ? null : new TransportConfig(cPtr, false);
      return ret;
    } 
  }

  public bool lockCodecEnabled {
    set {
      pjsua2PINVOKE.AccountMediaConfig_lockCodecEnabled_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.AccountMediaConfig_lockCodecEnabled_get(swigCPtr);
      return ret;
    } 
  }

  public bool streamKaEnabled {
    set {
      pjsua2PINVOKE.AccountMediaConfig_streamKaEnabled_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.AccountMediaConfig_streamKaEnabled_get(swigCPtr);
      return ret;
    } 
  }

  public pjmedia_srtp_use srtpUse {
    set {
      pjsua2PINVOKE.AccountMediaConfig_srtpUse_set(swigCPtr, (int)value);
    } 
    get {
      pjmedia_srtp_use ret = (pjmedia_srtp_use)pjsua2PINVOKE.AccountMediaConfig_srtpUse_get(swigCPtr);
      return ret;
    } 
  }

  public int srtpSecureSignaling {
    set {
      pjsua2PINVOKE.AccountMediaConfig_srtpSecureSignaling_set(swigCPtr, value);
    } 
    get {
      int ret = pjsua2PINVOKE.AccountMediaConfig_srtpSecureSignaling_get(swigCPtr);
      return ret;
    } 
  }

  public SrtpOpt srtpOpt {
    set {
      pjsua2PINVOKE.AccountMediaConfig_srtpOpt_set(swigCPtr, SrtpOpt.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.AccountMediaConfig_srtpOpt_get(swigCPtr);
      SrtpOpt ret = (cPtr == global::System.IntPtr.Zero) ? null : new SrtpOpt(cPtr, false);
      return ret;
    } 
  }

  public pjsua_ipv6_use ipv6Use {
    set {
      pjsua2PINVOKE.AccountMediaConfig_ipv6Use_set(swigCPtr, (int)value);
    } 
    get {
      pjsua_ipv6_use ret = (pjsua_ipv6_use)pjsua2PINVOKE.AccountMediaConfig_ipv6Use_get(swigCPtr);
      return ret;
    } 
  }

  public bool rtcpMuxEnabled {
    set {
      pjsua2PINVOKE.AccountMediaConfig_rtcpMuxEnabled_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.AccountMediaConfig_rtcpMuxEnabled_get(swigCPtr);
      return ret;
    } 
  }

  public RtcpFbConfig rtcpFbConfig {
    set {
      pjsua2PINVOKE.AccountMediaConfig_rtcpFbConfig_set(swigCPtr, RtcpFbConfig.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.AccountMediaConfig_rtcpFbConfig_get(swigCPtr);
      RtcpFbConfig ret = (cPtr == global::System.IntPtr.Zero) ? null : new RtcpFbConfig(cPtr, false);
      return ret;
    } 
  }

  public AccountMediaConfig() : this(pjsua2PINVOKE.new_AccountMediaConfig(), true) {
  }

  public override void readObject(ContainerNode node) {
    pjsua2PINVOKE.AccountMediaConfig_readObject(swigCPtr, ContainerNode.getCPtr(node));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public override void writeObject(ContainerNode node) {
    pjsua2PINVOKE.AccountMediaConfig_writeObject(swigCPtr, ContainerNode.getCPtr(node));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

}
