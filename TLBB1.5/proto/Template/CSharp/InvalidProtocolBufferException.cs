#region Copyright notice and license
// Protocol Buffers - Google's data interchange format
// Copyright 2008 Google Inc.  All rights reserved.
// http://github.com/jskeet/dotnet-protobufs/
// Original C++/Java/Python code:
// http://code.google.com/p/protobuf/
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//     * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//     * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System.IO;

namespace Google.ProtocolBuffers {
  /// <summary>
  /// Thrown when a protocol message being parsed is invalid in some way,
  /// e.g. it contains a malformed varint or a negative byte length.
  /// </summary>
  public sealed class InvalidProtocolBufferException : IOException {

    internal InvalidProtocolBufferException(string message)
      : base(message) {
    }

    internal static InvalidProtocolBufferException TruncatedMessage() {
      return new InvalidProtocolBufferException(
        "While parsing a protocol message, the input ended unexpectedly " +
        "in the middle of a field.  This could mean either than the " +
        "input has been truncated or that an embedded message " +
        "misreported its own length.");
    }

    internal static InvalidProtocolBufferException NegativeSize() {
      return new InvalidProtocolBufferException(
        "CodedInputStream encountered an embedded string or message " +
        "which claimed to have negative size.");
    }

    public static InvalidProtocolBufferException MalformedVarint() {
      return new InvalidProtocolBufferException(
        "CodedInputStream encountered a malformed varint.");
    }

    internal static InvalidProtocolBufferException InvalidTag() {
      return new InvalidProtocolBufferException(
        "Protocol message contained an invalid tag (zero).");
    }

    internal static InvalidProtocolBufferException InvalidEndTag() {
      return new InvalidProtocolBufferException(
        "Protocol message end-group tag did not match expected tag.");
    }

    internal static InvalidProtocolBufferException InvalidWireType() {
      return new InvalidProtocolBufferException(
        "Protocol message tag had invalid wire type.");
    }

    internal static InvalidProtocolBufferException RecursionLimitExceeded() {
      return new InvalidProtocolBufferException(
        "Protocol message had too many levels of nesting.  May be malicious.  " +
        "Use CodedInputStream.SetRecursionLimit() to increase the depth limit.");
    }

    internal static InvalidProtocolBufferException SizeLimitExceeded() {
      return new InvalidProtocolBufferException(
        "Protocol message was too large.  May be malicious.  " +
        "Use CodedInputStream.SetSizeLimit() to increase the size limit.");
    }

    internal static InvalidProtocolBufferException InvalidMessageStreamTag() {
      return new InvalidProtocolBufferException(
        "Stream of protocol messages had invalid tag. Expected tag is length-delimited field 1.");
    }
    internal static InvalidProtocolBufferException ErrorMsg(string msg)
    {
        return new InvalidProtocolBufferException(msg);       
    }
  }
}
