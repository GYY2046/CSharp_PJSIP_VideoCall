//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class ToneDescVector : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<ToneDesc>
 {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ToneDescVector(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ToneDescVector obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ToneDescVector() {
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
          pjsua2PINVOKE.delete_ToneDescVector(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public ToneDescVector(global::System.Collections.IEnumerable c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (ToneDesc element in c) {
      this.Add(element);
    }
  }

  public ToneDescVector(global::System.Collections.Generic.IEnumerable<ToneDesc> c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (ToneDesc element in c) {
      this.Add(element);
    }
  }

  public bool IsFixedSize {
    get {
      return false;
    }
  }

  public bool IsReadOnly {
    get {
      return false;
    }
  }

  public ToneDesc this[int index]  {
    get {
      return getitem(index);
    }
    set {
      setitem(index, value);
    }
  }

  public int Capacity {
    get {
      return (int)capacity();
    }
    set {
      if (value < size())
        throw new global::System.ArgumentOutOfRangeException("Capacity");
      reserve((uint)value);
    }
  }

  public int Count {
    get {
      return (int)size();
    }
  }

  public bool IsSynchronized {
    get {
      return false;
    }
  }

  public void CopyTo(ToneDesc[] array)
  {
    CopyTo(0, array, 0, this.Count);
  }

  public void CopyTo(ToneDesc[] array, int arrayIndex)
  {
    CopyTo(0, array, arrayIndex, this.Count);
  }

  public void CopyTo(int index, ToneDesc[] array, int arrayIndex, int count)
  {
    if (array == null)
      throw new global::System.ArgumentNullException("array");
    if (index < 0)
      throw new global::System.ArgumentOutOfRangeException("index", "Value is less than zero");
    if (arrayIndex < 0)
      throw new global::System.ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
    if (count < 0)
      throw new global::System.ArgumentOutOfRangeException("count", "Value is less than zero");
    if (array.Rank > 1)
      throw new global::System.ArgumentException("Multi dimensional array.", "array");
    if (index+count > this.Count || arrayIndex+count > array.Length)
      throw new global::System.ArgumentException("Number of elements to copy is too large.");
    for (int i=0; i<count; i++)
      array.SetValue(getitemcopy(index+i), arrayIndex+i);
  }

  public ToneDesc[] ToArray() {
    ToneDesc[] array = new ToneDesc[this.Count];
    this.CopyTo(array);
    return array;
  }

  global::System.Collections.Generic.IEnumerator<ToneDesc> global::System.Collections.Generic.IEnumerable<ToneDesc>.GetEnumerator() {
    return new ToneDescVectorEnumerator(this);
  }

  global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() {
    return new ToneDescVectorEnumerator(this);
  }

  public ToneDescVectorEnumerator GetEnumerator() {
    return new ToneDescVectorEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class ToneDescVectorEnumerator : global::System.Collections.IEnumerator
    , global::System.Collections.Generic.IEnumerator<ToneDesc>
  {
    private ToneDescVector collectionRef;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public ToneDescVectorEnumerator(ToneDescVector collection) {
      collectionRef = collection;
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public ToneDesc Current {
      get {
        if (currentIndex == -1)
          throw new global::System.InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new global::System.InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new global::System.InvalidOperationException("Collection modified.");
        return (ToneDesc)currentObject;
      }
    }

    // Type-unsafe IEnumerator.Current
    object global::System.Collections.IEnumerator.Current {
      get {
        return Current;
      }
    }

    public bool MoveNext() {
      int size = collectionRef.Count;
      bool moveOkay = (currentIndex+1 < size) && (size == currentSize);
      if (moveOkay) {
        currentIndex++;
        currentObject = collectionRef[currentIndex];
      } else {
        currentObject = null;
      }
      return moveOkay;
    }

    public void Reset() {
      currentIndex = -1;
      currentObject = null;
      if (collectionRef.Count != currentSize) {
        throw new global::System.InvalidOperationException("Collection modified.");
      }
    }

    public void Dispose() {
        currentIndex = -1;
        currentObject = null;
    }
  }

  public void Clear() {
    pjsua2PINVOKE.ToneDescVector_Clear(swigCPtr);
  }

  public void Add(ToneDesc x) {
    pjsua2PINVOKE.ToneDescVector_Add(swigCPtr, ToneDesc.getCPtr(x));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  private uint size() {
    uint ret = pjsua2PINVOKE.ToneDescVector_size(swigCPtr);
    return ret;
  }

  private uint capacity() {
    uint ret = pjsua2PINVOKE.ToneDescVector_capacity(swigCPtr);
    return ret;
  }

  private void reserve(uint n) {
    pjsua2PINVOKE.ToneDescVector_reserve(swigCPtr, n);
  }

  public ToneDescVector() : this(pjsua2PINVOKE.new_ToneDescVector__SWIG_0(), true) {
  }

  public ToneDescVector(ToneDescVector other) : this(pjsua2PINVOKE.new_ToneDescVector__SWIG_1(ToneDescVector.getCPtr(other)), true) {
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public ToneDescVector(int capacity) : this(pjsua2PINVOKE.new_ToneDescVector__SWIG_2(capacity), true) {
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  private ToneDesc getitemcopy(int index) {
    ToneDesc ret = new ToneDesc(pjsua2PINVOKE.ToneDescVector_getitemcopy(swigCPtr, index), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private ToneDesc getitem(int index) {
    ToneDesc ret = new ToneDesc(pjsua2PINVOKE.ToneDescVector_getitem(swigCPtr, index), false);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void setitem(int index, ToneDesc val) {
    pjsua2PINVOKE.ToneDescVector_setitem(swigCPtr, index, ToneDesc.getCPtr(val));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddRange(ToneDescVector values) {
    pjsua2PINVOKE.ToneDescVector_AddRange(swigCPtr, ToneDescVector.getCPtr(values));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public ToneDescVector GetRange(int index, int count) {
    global::System.IntPtr cPtr = pjsua2PINVOKE.ToneDescVector_GetRange(swigCPtr, index, count);
    ToneDescVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new ToneDescVector(cPtr, true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Insert(int index, ToneDesc x) {
    pjsua2PINVOKE.ToneDescVector_Insert(swigCPtr, index, ToneDesc.getCPtr(x));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void InsertRange(int index, ToneDescVector values) {
    pjsua2PINVOKE.ToneDescVector_InsertRange(swigCPtr, index, ToneDescVector.getCPtr(values));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAt(int index) {
    pjsua2PINVOKE.ToneDescVector_RemoveAt(swigCPtr, index);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveRange(int index, int count) {
    pjsua2PINVOKE.ToneDescVector_RemoveRange(swigCPtr, index, count);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public static ToneDescVector Repeat(ToneDesc value, int count) {
    global::System.IntPtr cPtr = pjsua2PINVOKE.ToneDescVector_Repeat(ToneDesc.getCPtr(value), count);
    ToneDescVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new ToneDescVector(cPtr, true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reverse() {
    pjsua2PINVOKE.ToneDescVector_Reverse__SWIG_0(swigCPtr);
  }

  public void Reverse(int index, int count) {
    pjsua2PINVOKE.ToneDescVector_Reverse__SWIG_1(swigCPtr, index, count);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetRange(int index, ToneDescVector values) {
    pjsua2PINVOKE.ToneDescVector_SetRange(swigCPtr, index, ToneDescVector.getCPtr(values));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

}
