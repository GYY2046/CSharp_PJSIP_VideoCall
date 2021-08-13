//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class ContainerNode : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ContainerNode(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ContainerNode obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ContainerNode() {
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
          pjsua2PINVOKE.delete_ContainerNode(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public bool hasUnread() {
    bool ret = pjsua2PINVOKE.ContainerNode_hasUnread(swigCPtr);
    return ret;
  }

  public string unreadName() {
    string ret = pjsua2PINVOKE.ContainerNode_unreadName(swigCPtr);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int readInt(string name) {
    int ret = pjsua2PINVOKE.ContainerNode_readInt__SWIG_0(swigCPtr, name);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int readInt() {
    int ret = pjsua2PINVOKE.ContainerNode_readInt__SWIG_1(swigCPtr);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public float readNumber(string name) {
    float ret = pjsua2PINVOKE.ContainerNode_readNumber__SWIG_0(swigCPtr, name);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public float readNumber() {
    float ret = pjsua2PINVOKE.ContainerNode_readNumber__SWIG_1(swigCPtr);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool readBool(string name) {
    bool ret = pjsua2PINVOKE.ContainerNode_readBool__SWIG_0(swigCPtr, name);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool readBool() {
    bool ret = pjsua2PINVOKE.ContainerNode_readBool__SWIG_1(swigCPtr);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string readString(string name) {
    string ret = pjsua2PINVOKE.ContainerNode_readString__SWIG_0(swigCPtr, name);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string readString() {
    string ret = pjsua2PINVOKE.ContainerNode_readString__SWIG_1(swigCPtr);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public StringVector readStringVector(string name) {
    StringVector ret = new StringVector(pjsua2PINVOKE.ContainerNode_readStringVector__SWIG_0(swigCPtr, name), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public StringVector readStringVector() {
    StringVector ret = new StringVector(pjsua2PINVOKE.ContainerNode_readStringVector__SWIG_1(swigCPtr), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void readObject(PersistentObject obj) {
    pjsua2PINVOKE.ContainerNode_readObject(swigCPtr, PersistentObject.getCPtr(obj));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public ContainerNode readContainer(string name) {
    ContainerNode ret = new ContainerNode(pjsua2PINVOKE.ContainerNode_readContainer__SWIG_0(swigCPtr, name), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ContainerNode readContainer() {
    ContainerNode ret = new ContainerNode(pjsua2PINVOKE.ContainerNode_readContainer__SWIG_1(swigCPtr), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ContainerNode readArray(string name) {
    ContainerNode ret = new ContainerNode(pjsua2PINVOKE.ContainerNode_readArray__SWIG_0(swigCPtr, name), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ContainerNode readArray() {
    ContainerNode ret = new ContainerNode(pjsua2PINVOKE.ContainerNode_readArray__SWIG_1(swigCPtr), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void writeNumber(string name, float num) {
    pjsua2PINVOKE.ContainerNode_writeNumber(swigCPtr, name, num);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void writeInt(string name, int num) {
    pjsua2PINVOKE.ContainerNode_writeInt(swigCPtr, name, num);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void writeBool(string name, bool value) {
    pjsua2PINVOKE.ContainerNode_writeBool(swigCPtr, name, value);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void writeString(string name, string value) {
    pjsua2PINVOKE.ContainerNode_writeString(swigCPtr, name, value);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void writeStringVector(string name, StringVector arr) {
    pjsua2PINVOKE.ContainerNode_writeStringVector(swigCPtr, name, StringVector.getCPtr(arr));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void writeObject(PersistentObject obj) {
    pjsua2PINVOKE.ContainerNode_writeObject(swigCPtr, PersistentObject.getCPtr(obj));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public ContainerNode writeNewContainer(string name) {
    ContainerNode ret = new ContainerNode(pjsua2PINVOKE.ContainerNode_writeNewContainer(swigCPtr, name), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ContainerNode writeNewArray(string name) {
    ContainerNode ret = new ContainerNode(pjsua2PINVOKE.ContainerNode_writeNewArray(swigCPtr, name), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ContainerNode() : this(pjsua2PINVOKE.new_ContainerNode(), true) {
  }

}
