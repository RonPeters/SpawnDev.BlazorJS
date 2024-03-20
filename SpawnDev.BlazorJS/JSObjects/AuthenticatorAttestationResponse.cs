﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AuthenticatorAttestationResponse interface of the Web Authentication API is the result of a WebAuthn credential registration. It contains information about the credential that the server needs to perform WebAuthn assertions, such as its credential ID and public key.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/AuthenticatorAttestationResponse
    /// </summary>
    public class AuthenticatorAttestationResponse : AuthenticatorResponse
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AuthenticatorAttestationResponse(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An ArrayBuffer containing authenticator data and an attestation statement for a new key pair generated by the authenticator.
        /// </summary>
        public ArrayBuffer AttestationObject => JSRef.Get<ArrayBuffer>("attestationObject");
        /// <summary>
        /// Returns an ArrayBuffer containing the authenticator data contained within the AuthenticatorAttestationResponse.attestationObject property.
        /// </summary>
        /// <returns></returns>
        public ArrayBuffer GetAuthenticatorData() => JSRef.Call<ArrayBuffer>("getAuthenticatorData");
        /// <summary>
        /// Returns an ArrayBuffer containing the DER SubjectPublicKeyInfo of the new credential (see Subject Public Key Info), or null if this is not available.
        /// </summary>
        /// <returns></returns>
        public ArrayBuffer GetPublicKey() => JSRef.Call<ArrayBuffer>("getPublicKey");
        /// <summary>
        /// Returns a number that is equal to a COSE Algorithm Identifier, representing the cryptographic algorithm used for the new credential.
        /// </summary>
        /// <returns></returns>
        public int GetPublicKeyAlgorithm() => JSRef.Call<int>("getPublicKeyAlgorithm");
        /// <summary>
        /// Returns an array of strings describing which transport methods (e.g., usb, nfc) are believed to be supported with the authenticator. The array may be empty if the information is not available.
        /// </summary>
        /// <returns></returns>
        public List<string> GetTransports() => JSRef.Call<List<string>>("getTransports");
    }
}