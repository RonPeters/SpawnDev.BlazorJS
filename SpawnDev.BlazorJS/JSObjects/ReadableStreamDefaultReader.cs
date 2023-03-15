﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    // https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultReader
    public class ReadableStreamDefaultReader : JSObject {
        public ReadableStreamDefaultReader(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Closed => JSRef.Get<bool>("closed");
        public async Task Cancel() => await JSRef.CallVoidAsync("cancel");
        public async Task<ReadableStreamReaderReadResponse> Read() => await JSRef.CallAsync<ReadableStreamReaderReadResponse>("read");
        public void ReleaseLock() => JSRef.CallVoid("releaseLock");
    }
}
