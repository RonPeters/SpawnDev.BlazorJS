﻿using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;
using System.Reflection;

namespace SpawnDev.BlazorJS
{
    public static class IJSInProcessObjectReferenceExtensions
    {
        static PropertyInfo? JSObjectReferenceIdProp = null;
        public static T[]? AsArray<T>(this IJSInProcessObjectReference _ref) where T : JSObject => JSInterop.ReturnArrayJSObjects<T>(_ref);
        public static IJSInProcessObjectReference[]? AsArray(this IJSInProcessObjectReference _ref) => JSInterop.ReturnArrayJSObjectReferences(_ref);
        /// <summary>
        /// Import the IJSInProcessObjectReference instance from Javascript as T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ref"></param>
        /// <returns></returns>
        public static T As<T>(this IJSInProcessObjectReference _ref) => JSInterop.ReturnMe<T>(_ref);
        public static object As(this IJSInProcessObjectReference _ref, Type returnType) => JSInterop.ReturnMe(returnType, _ref)!;
        public static IJSInProcessObjectReference CreateCopy(this IJSInProcessObjectReference _ref) => JSInterop.ReturnMe<IJSInProcessObjectReference>(_ref);
        public static long GetJSRefId(this IJSInProcessObjectReference _ref)
        {
            if (JSObjectReferenceIdProp == null)
            {
                JSObjectReferenceIdProp = typeof(JSObjectReference).GetProperty("Id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            }
            return (long)JSObjectReferenceIdProp.GetValue(_ref);
        }

        public static string GetConstructorName(this IJSInProcessObjectReference _ref) => JSInterop.Get<string>(_ref, "constructor.name");
        public static List<string> GetPropertyNames(this IJSInProcessObjectReference _ref, bool hasOwnProperty = false) => JSInterop.GetPropertyNames(_ref, null, hasOwnProperty);
        public static string PropertyType(this IJSInProcessObjectReference _ref, object? identifier = null) => JSInterop.TypeOf(_ref, identifier);
        public static bool PropertyIsUndefined(this IJSInProcessObjectReference _ref, object? identifier = null) => JSInterop.TypeOf(_ref, identifier) == "undefined";
        public static string PropertyInstanceOf(this IJSInProcessObjectReference _ref, object? identifier = null) => JSInterop.InstanceOf(_ref, identifier);

        #region IJSInProcessObjectReference Base Accessors
        public static void Set(this IJSInProcessObjectReference targetObject, object identifier, object? value) => JSInterop.Set(targetObject, identifier, value);
        //public static void Set(this IJSInProcessObjectReference targetObject, int identifier, object? value) => JSInterop.Set(targetObject, identifier, value);
        //public static void Set(this IJSInProcessObjectReference targetObject, long identifier, object? value) => JSInterop.Set(targetObject, identifier, value);
        //public static void Set(this IJSInProcessObjectReference targetObject, object identifier, object? value) => JSInterop.Set(targetObject, identifier, value);
        public static T Get<T>(this IJSInProcessObjectReference targetObject, object identifier) => JSInterop.Get<T>(targetObject, identifier);
        //public static T Get<T>(this IJSInProcessObjectReference targetObject, int identifier) => JSInterop.Get<T>(targetObject, identifier);
        //public static T Get<T>(this IJSInProcessObjectReference targetObject, long identifier) => JSInterop.Get<T>(targetObject, identifier);
        public static object? Get(this IJSInProcessObjectReference targetObject, Type returnType, object identifier) => JSInterop.Get(returnType, targetObject, identifier);
        //public static object? Get(this IJSInProcessObjectReference targetObject, Type returnType, int identifier) => JSInterop.Get(returnType, targetObject, identifier);

        #region IJSInProcessObjectReference Get Async
        public static Task<T> GetAsync<T>(this IJSInProcessObjectReference targetObject, object identifier) => JSInterop.GetAsync<T>(targetObject, identifier);
        //public static Task<object?> GetAsync(this IJSInProcessObjectReference targetObject, Type returnType, object identifier)=> _JSInteropCallAsync(returnType, "_get", targetObject, identifier);
        #endregion
        #region IJSInProcessObjectReference Call Sync
        public static T CallApply<T>(this IJSInProcessObjectReference targetObject, object identifier, object?[]? args = null) => JSInterop.Call<T>(targetObject, identifier, args);
        public static object? CallApply(this IJSInProcessObjectReference targetObject, Type returnType, object identifier, object?[]? args = null) => JSInterop.Call(returnType, targetObject, identifier, args);
        public static void CallApplyVoid(this IJSInProcessObjectReference targetObject, object identifier, object?[]? args = null) => JSInterop.CallVoid(targetObject, identifier, args);
        #endregion
        #region IJSInProcessObjectReference Call Async
        public static Task<T> CallApplyAsync<T>(this IJSInProcessObjectReference targetObject, object identifier, object?[]? args = null) => JSInterop.CallAsync<T>(targetObject, identifier, args);
        //        public static Task<object?> CallApplyAsync(this IJSInProcessObjectReference targetObject, Type returnType, object identifier, object?[]? args = null) => _JSInteropCallAsync(returnType, "_call", targetObject, identifier, args);
        public static Task CallApplyVoidAsync(this IJSInProcessObjectReference targetObject, object identifier, object?[]? args = null) => JSInterop.CallVoidAsync(targetObject, identifier, args);
        #endregion
        #endregion

        // call with up to 10 arguments
        // used instead of "params" because params has an issue that can cause unexpected behavior
        // (Example: if a single argument of an array of string is passed, the params variable will be an array of string instead of a 2 dimensiaonal array with the first item being the array of strings passed) 
        #region IJSInProcessObjectReference Call Sync 
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier) => CallApply<T>(_ref, identifier);
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0) => CallApply<T>(_ref, identifier, new object?[] { arg0 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static T Call<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApply<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier) => CallApply(_ref, returnType, identifier);
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0) => CallApply(_ref, returnType, identifier, new object?[] { arg0 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static object? Call(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApply(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier) => CallApplyVoid(_ref, identifier);
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0) => CallApplyVoid(_ref, identifier, new object?[] { arg0 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static void CallVoid(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyVoid(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
        #endregion


        #region IJSInProcessObjectReference Call Async
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier) => CallApplyAsync<T>(_ref, identifier);
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0 });
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1 });
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2 });
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static Task<T> CallAsync<T>(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyAsync<T>(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier) => CallApplyAsync(_ref, returnType, identifier);
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0 });
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1 });
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2 });
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        //public static Task<object?> CallAsync(this IJSInProcessObjectReference _ref, Type returnType, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyAsync(_ref, returnType, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier) => CallApplyVoidAsync(_ref, identifier);
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0 });
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1 });
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2 });
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3 });
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4 });
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static Task CallVoidAsync(this IJSInProcessObjectReference _ref, object identifier, object? arg0, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, object? arg9) => CallApplyVoidAsync(_ref, identifier, new object?[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });


        #endregion

        public static T NewApply<T>(this IJSInProcessObjectReference _ref, object?[]? args = null) => JSInterop.ReturnNew<T>(_ref, args);
        public static IJSInProcessObjectReference NewApply(this IJSInProcessObjectReference _ref, object?[]? args = null) => JSInterop.ReturnNew<IJSInProcessObjectReference>(_ref, args);
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref) => NewApply(_ref);
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0) => NewApply(_ref, new object[] { arg0 });
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0, object arg1) => NewApply(_ref, new object[] { arg0, arg1 });
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2) => NewApply(_ref, new object[] { arg0, arg1, arg2 });
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3) => NewApply(_ref, new object[] { arg0, arg1, arg2, arg3 });
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4) => NewApply(_ref, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => NewApply(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6) => NewApply(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7) => NewApply(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8) => NewApply(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static IJSInProcessObjectReference New(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9) => NewApply(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        public static T New<T>(this IJSInProcessObjectReference _ref) => NewApply<T>(_ref);
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0) => NewApply<T>(_ref, new object[] { arg0 });
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0, object arg1) => NewApply<T>(_ref, new object[] { arg0, arg1 });
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2) => NewApply<T>(_ref, new object[] { arg0, arg1, arg2 });
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3) => NewApply<T>(_ref, new object[] { arg0, arg1, arg2, arg3 });
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4) => NewApply<T>(_ref, new object[] { arg0, arg1, arg2, arg3, arg4 });
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5) => NewApply<T>(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5 });
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6) => NewApply<T>(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6 });
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7) => NewApply<T>(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8) => NewApply<T>(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });
        public static T New<T>(this IJSInProcessObjectReference _ref, object arg0, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9) => NewApply<T>(_ref, new object[] { arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });
    }
}
