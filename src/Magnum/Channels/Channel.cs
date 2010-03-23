// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Magnum.Channels
{
	using System;

	/// <summary>
	/// A channel represents a one-way communication, well, channel
	/// </summary>
	public interface Channel :
		IDisposable
	{
	}

	/// <summary>
	/// A one-way communication containing messages of the specified type
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface Channel<T> :
		Channel
	{
		/// <summary>
		/// Send a message to the channel
		/// </summary>
		/// <param name="message">The message to send</param>
		void Send(T message);
	}
}