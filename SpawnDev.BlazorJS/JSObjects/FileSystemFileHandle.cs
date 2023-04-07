﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/File
    public class FileSystemFileHandle : FileSystemHandle
    {
        public FileSystemFileHandle(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Task<File> GetFile() => JSRef.CallAsync<File>("getFile");
        public Task<FileSystemWritableFileStream> CreateWritable() => JSRef.CallAsync<FileSystemWritableFileStream>("createWritable");
        
    }
}
