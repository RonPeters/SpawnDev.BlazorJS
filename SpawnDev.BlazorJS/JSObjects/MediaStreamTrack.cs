﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaStreamTrack interface of the Media Capture and Streams API represents a single media track within a stream; typically, these are audio or video tracks, but other track types may exist as well.
    /// </summary>
    public class MediaStreamTrack : EventTarget
    {
        /// <summary>
        /// A Boolean whose value of true if the track is enabled, that is allowed to render the media source stream; or false if it is disabled, that is not rendering the media source stream but silence and blackness. If the track has been disconnected, this value can be changed but has no more effect.<br />
        /// Note: You can implement standard "mute" functionality by setting enabled to false. The muted property refers to a condition in which there's no media because of a technical issue.
        /// </summary>
        public bool Enabled { get => JSRef.Get<bool>("enabled"); set => JSRef.Set("enabled", value); }
        /// <summary>
        /// Returns a Boolean value indicating whether the track is unable to provide media data due to a technical issue.<br />
        /// Note: You can implement standard "mute" functionality by setting enabled to false, and unmute the media by setting it back to true again.
        /// </summary>
        public bool Muted => JSRef.Get<bool>("muted");
        /// <summary>
        /// Returns a string containing a unique identifier (GUID) for the track; it is generated by the browser.
        /// </summary>
        public string Id => JSRef.Get<string>("id");
        /// <summary>
        /// Returns a string set to "audio" if the track is an audio track and to "video", if it is a video track. It doesn't change if the track is disassociated from its source.
        /// </summary>
        public string Kind => JSRef.Get<string>("kind");
        public string ContentHint => JSRef.Get<string>("contentHint");
        /// <summary>
        /// Returns a string containing a user agent-assigned label that identifies the track source, as in "internal microphone". The string may be left empty and is empty as long as no source has been connected. When the track is disassociated from its source, the label is not changed.
        /// </summary>
        public string Label => JSRef.Get<string>("label");
        /// <summary>
        /// Returns an enumerated string giving the status of the track. This will be one of the following values:<br />
        /// "live" which indicates that an input is connected and does its best-effort in providing real-time data. In that case, the output of data can be switched on or off using the enabled attribute.<br />
        /// "ended" which indicates that the input is not giving any more data and will never provide new data.
        /// </summary>
        public string ReadyState => JSRef.Get<string>("readyState");

        public MediaStreamTrack(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a MediaTrackSettings object containing the current values of each of the MediaStreamTrack's constrainable properties.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetSettings<T>() where T : MediaStreamTrackSettings => JSRef.Call<T>("getSettings");
        /// <summary>
        /// Returns a MediaTrackSettings object containing the current values of each of the MediaStreamTrack's constrainable properties.
        /// </summary>
        /// <returns></returns>
        public MediaStreamTrackSettings GetSettings() => JSRef.Call<MediaStreamTrackSettings>("getSettings");
        /// <summary>
        /// Stops playing the source associated to the track, both the source and the track are disassociated. The track state is set to ended.
        /// </summary>
        public void Stop() => JSRef.CallVoid("stop");
        /// <summary>
        /// The clone() method of the MediaStreamTrack interface creates a duplicate of the MediaStreamTrack. This new MediaStreamTrack object is identical except for its unique id.
        /// </summary>
        /// <returns>A new MediaStreamTrack instance which is identical to the one clone() was called, except for its new unique id.</returns>
        public MediaStreamTrack Clone() => JSRef.Call<MediaStreamTrack>("clone");
        /// <summary>
        /// The applyConstraints() method of the MediaStreamTrack interface applies a set of constraints to the track; these constraints let the website or app establish ideal values and acceptable ranges of values for the constrainable properties of the track, such as frame rate, dimensions, echo cancellation, and so forth.
        /// </summary>
        /// <param name="constraints"></param>
        /// <returns></returns>
        public Task ApplyConstraints(object constraints) => JSRef.CallVoidAsync("applyConstraints", constraints);
        /// <summary>
        /// The applyConstraints() method of the MediaStreamTrack interface applies a set of constraints to the track; these constraints let the website or app establish ideal values and acceptable ranges of values for the constrainable properties of the track, such as frame rate, dimensions, echo cancellation, and so forth.
        /// </summary>
        /// <returns></returns>
        public Task ApplyConstraints() => JSRef.CallVoidAsync("applyConstraints");
    }
}
