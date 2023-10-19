﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Array : JSObject
    {
        public Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Array() : base(JS.New(nameof(Array))) { }
        public Array(uint length) : base(JS.New(nameof(Array), length)) { }
        public Array(params object[] values) : base(JS.NewApply(nameof(Array), values)) { }
        public int Length => JSRef.Get<int>("length");
        public void Push(object? value) => JSRef.CallVoid("push", value);
        public void Unshift(object? value) => JSRef.CallVoid("unshift", value);
        public T At<T>(int index) => JSRef.Call<T>("at", index);
        public T Pop<T>() => JSRef.Call<T>("pop");
        public T Shift<T>() => JSRef.Call<T>("shift");
        public void SetItem<T>(int index, object? value) => JSRef.Set(index, value);
        public T GetItem<T>(int index) => JSRef.Get<T>(index);
        public object? GetItem(Type type, int index) => JSRef.Get(type, index);
        public Array Concat(Array array) => JSRef.Call<Array>("concat", array);
        public string Join(string separator = "") => JSRef.Call<string>("join", separator);
        public Array<TResult> Map<TResult>(Function function) => JSRef.Call<Array<TResult>>("map", function);
        public Array<TResult> Map<T, TResult>(Func<T, TResult> mapTo)
        {
            using var cb = Callback.Create(mapTo);
            return JSRef.Call<Array<TResult>>("map", cb);
        }
        public Array<T> Filter<T>(Func<T, bool> filter)
        {
            using var cb = Callback.Create(filter);
            return JSRef.Call<Array<T>>("filter", cb);
        }
        public void ForEach<T>(Action<T> mapTo)
        {
            using var cb = Callback.Create(mapTo);
            JSRef.CallVoid("forEach", cb);
        }
        public T[] ToArray<T>() => Enumerable.Range(0, Length).Select(i => At<T>(i)).ToArray();
        public T[] ToArray<T>(int start, int count) => Enumerable.Range(start, count).Select(i => At<T>(i)).ToArray();
    }
    public class Array<T> : JSObject
    {
        public T this[int index]
        {
            get => GetItem(index);
            set => SetItem(index, value);
        }
        public Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Array() : base(JS.New(nameof(Array))) { }
        public Array(uint length) : base(JS.New(nameof(Array), length)) { }
        public Array(params object[] values) : base(JS.NewApply(nameof(Array), values)) { }
        public int Length => JSRef.Get<int>("length");
        public void Push(object? value) => JSRef.CallVoid("push", value);
        public void Unshift(object? value) => JSRef.CallVoid("unshift", value);
        public T At(int index) => JSRef.Call<T>("at", index);
        public T Pop() => JSRef.Call<T>("pop");
        public T Shift() => JSRef.Call<T>("shift");
        public void SetItem(int index, object? value) => JSRef.Set(index, value);
        public T GetItem(int index) => JSRef.Get<T>(index);
        public object? GetItem(Type type, int index) => JSRef.Get(type, index);
        public Array Concat(Array array) => JSRef.Call<Array>("concat", array);
        public string Join(string separator = "") => JSRef.Call<string>("join", separator);
        public Array<TResult> Map<TResult>(Function function) => JSRef.Call<Array<TResult>>("map", function);
        public Array<TResult> Map<TResult>(Func<T, TResult> mapTo)
        {
            using var cb = Callback.Create(mapTo);
            return JSRef.Call<Array<TResult>>("map", cb);
        }
        public Array<T> Filter(Func<T, bool> filter)
        {
            using var cb = Callback.Create(filter);
            return JSRef.Call<Array<T>>("filter", cb);
        }
        public void ForEach(Action<T> fn)
        {
            using var cb = Callback.Create(fn);
            JSRef.CallVoid("forEach", cb);
        }
        //public T[] ToArray() => JS.ReturnMe<T[]>(JSRef);
        public T[] ToArray() => Enumerable.Range(0, Length).Select(i => At(i)).ToArray();
        public T[] ToArray(int start, int count) => Enumerable.Range(start, count).Select(i => At(i)).ToArray();
        public List<T> ToList() => Enumerable.Range(0, Length).Select(i => At(i)).ToList();
        public List<T> ToList(int start, int count) => Enumerable.Range(start, count).Select(i => At(i)).ToList();
    }
}
