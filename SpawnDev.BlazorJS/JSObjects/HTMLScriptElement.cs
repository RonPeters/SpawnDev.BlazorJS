﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class HTMLScriptElement : HTMLElement
    {
        public string Src { get => JSRef.Get<string>("src"); set => JSRef.Set("src", value); }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLScriptElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLScriptElement() : base(JS.DocumentCreateElement("script")) { }
        public Task OnLoadAsync()
        {
            var taskCompletionSource = new TaskCompletionSource();
            Action? cleanUp = null;
            var onLoad = new Action<Event>((e) =>
            {
                cleanUp?.Invoke();
                taskCompletionSource.TrySetResult();
            });
            var onError = new Action<Event>((e) =>
            {
                cleanUp?.Invoke();
                taskCompletionSource.TrySetException(new Exception("Script load failed"));
            });
            cleanUp = new Action(() => {
                OnLoad -= onLoad;
                OnError -= onError;
            });
            OnLoad += onLoad;
            OnError += onError;
            return taskCompletionSource.Task;
        }
    }
}
