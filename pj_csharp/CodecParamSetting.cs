//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class CodecParamSetting : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal CodecParamSetting(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CodecParamSetting obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~CodecParamSetting() {
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
          pjsua2PINVOKE.delete_CodecParamSetting(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public uint frmPerPkt {
    set {
      pjsua2PINVOKE.CodecParamSetting_frmPerPkt_set(swigCPtr, value);
    } 
    get {
      uint ret = pjsua2PINVOKE.CodecParamSetting_frmPerPkt_get(swigCPtr);
      return ret;
    } 
  }

  public bool vad {
    set {
      pjsua2PINVOKE.CodecParamSetting_vad_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.CodecParamSetting_vad_get(swigCPtr);
      return ret;
    } 
  }

  public bool cng {
    set {
      pjsua2PINVOKE.CodecParamSetting_cng_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.CodecParamSetting_cng_get(swigCPtr);
      return ret;
    } 
  }

  public bool penh {
    set {
      pjsua2PINVOKE.CodecParamSetting_penh_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.CodecParamSetting_penh_get(swigCPtr);
      return ret;
    } 
  }

  public bool plc {
    set {
      pjsua2PINVOKE.CodecParamSetting_plc_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.CodecParamSetting_plc_get(swigCPtr);
      return ret;
    } 
  }

  public bool reserved {
    set {
      pjsua2PINVOKE.CodecParamSetting_reserved_set(swigCPtr, value);
    } 
    get {
      bool ret = pjsua2PINVOKE.CodecParamSetting_reserved_get(swigCPtr);
      return ret;
    } 
  }

  public CodecFmtpVector encFmtp {
    set {
      pjsua2PINVOKE.CodecParamSetting_encFmtp_set(swigCPtr, CodecFmtpVector.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.CodecParamSetting_encFmtp_get(swigCPtr);
      CodecFmtpVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new CodecFmtpVector(cPtr, false);
      return ret;
    } 
  }

  public CodecFmtpVector decFmtp {
    set {
      pjsua2PINVOKE.CodecParamSetting_decFmtp_set(swigCPtr, CodecFmtpVector.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = pjsua2PINVOKE.CodecParamSetting_decFmtp_get(swigCPtr);
      CodecFmtpVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new CodecFmtpVector(cPtr, false);
      return ret;
    } 
  }

  public CodecParamSetting() : this(pjsua2PINVOKE.new_CodecParamSetting(), true) {
  }

}
