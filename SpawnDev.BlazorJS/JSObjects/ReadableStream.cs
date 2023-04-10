﻿using Microsoft.JSInterop;
using System.Dynamic;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ReadableStream : JSObject {
        public ReadableStream(IJSInProcessObjectReference _ref) : base(_ref) { }

        CallbackGroup callbacks = new CallbackGroup();

        public void OnReadable(Action callback) { JSRef.CallVoid("on", "readable", Callback.Create(callback, callbacks)); }
        public void OnEnd(Action callback) { JSRef.CallVoid("on", "end", Callback.Create(callback, callbacks)); }

        public ReadableStream(ExpandoObject options) : base(JS.New(nameof(ReadableStream), options)) { }

        public Uint8Array? Read() {
            Uint8Array? ret = null;
            try {
                ret = JSRef.Call<Uint8Array>("read");
            }
            catch { }
            return ret;
        }

        public AsyncIterator GetAsyncIterator() {
            var ret = JSRef.Get<AsyncIterator>("Symbol.asyncIterator");
            return ret;
        }

        public ReadableStreamDefaultReader GetReader() {
            return JSRef.Call<ReadableStreamDefaultReader>("getReader");
        }

        public void Destroy() {
            JSRef.CallVoid("destroy");
        }

        protected override void LosingReference()
        {
            callbacks.Dispose();
        }
    }
}
