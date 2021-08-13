//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class BuddyInfo : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BuddyInfo(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BuddyInfo obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~BuddyInfo() {
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
          pjsua2PINVOKE.delete_BuddyInfo(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public string uri {
    set {
      pjsua2PINVOKE.BuddyInfo_uri_set(swigCPtr, value);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      string ret = pjsua2PINVOKE.BuddyInfo_uri_get(swigCPtr);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public string contact {
    set {
      pjsua2PINVOKE.BuddyInfo_contact_set(swigCPtr, value);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      string ret = pjsua2PINVOKE.BuddyInfo_contact_get(swigCPtr);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public bool presMonitorEnabled {
    set {
      pjsua2PINVOKE.BuddyInfo_presMonitorEnabled_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.BuddyInfo_presMonitorEnabled_get(swigCPtr);
      return ret;
    } 
  }

  public pjsip_evsub_state subState {
    set {
      pjsua2PINVOKE.BuddyInfo_subState_set(swigCPtr, (int)value);
    } 
    get {
      pjsip_evsub_state ret = (pjsip_evsub_state)pjsua2PINVOKE.BuddyInfo_subState_get(swigCPtr);
      return ret;
    } 
  }

  public string subStateName {
    set {
      pjsua2PINVOKE.BuddyInfo_subStateName_set(swigCPtr, value);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      string ret = pjsua2PINVOKE.BuddyInfo_subStateName_get(swigCPtr);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public pjsip_status_code subTermCode {
    set {
      pjsua2PINVOKE.BuddyInfo_subTermCode_set(swigCPtr, (int)value);
    } 
    get {
      pjsip_status_code ret = (pjsip_status_code)pjsua2PINVOKE.BuddyInfo_subTermCode_get(swigCPtr);
      return ret;
    } 
  }

  public string subTermReason {
    set {
      pjsua2PINVOKE.BuddyInfo_subTermReason_set(swigCPtr, value);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      string ret = pjsua2PINVOKE.BuddyInfo_subTermReason_get(swigCPtr);
      if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public PresenceStatus presStatus {
    set {
      pjsua2PINVOKE.BuddyInfo_presStatus_set(swigCPtr, PresenceStatus.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.BuddyInfo_presStatus_get(swigCPtr);
      PresenceStatus ret = (cPtr == global::System.IntPtr.Zero) ? null : new PresenceStatus(cPtr, false);
      return ret;
    } 
  }

  public BuddyInfo() : this(pjsua2PINVOKE.new_BuddyInfo(), true) {
  }

}
