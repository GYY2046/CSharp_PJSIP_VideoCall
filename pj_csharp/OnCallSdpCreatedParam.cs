//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class OnCallSdpCreatedParam : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal OnCallSdpCreatedParam(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(OnCallSdpCreatedParam obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~OnCallSdpCreatedParam() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          pjsua2PINVOKE.delete_OnCallSdpCreatedParam(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public SdpSession sdp {
    set {
      pjsua2PINVOKE.OnCallSdpCreatedParam_sdp_set(swigCPtr, SdpSession.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.OnCallSdpCreatedParam_sdp_get(swigCPtr);
      SdpSession ret = (cPtr == global::System.IntPtr.Zero) ? null : new SdpSession(cPtr, false);
      return ret;
    } 
  }

  public SdpSession remSdp {
    set {
      pjsua2PINVOKE.OnCallSdpCreatedParam_remSdp_set(swigCPtr, SdpSession.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.OnCallSdpCreatedParam_remSdp_get(swigCPtr);
      SdpSession ret = (cPtr == global::System.IntPtr.Zero) ? null : new SdpSession(cPtr, false);
      return ret;
    } 
  }

  public OnCallSdpCreatedParam() : this(pjsua2PINVOKE.new_OnCallSdpCreatedParam(), true) {
  }

}
