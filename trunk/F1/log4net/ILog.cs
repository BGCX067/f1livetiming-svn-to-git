﻿/*
 *  f1livetiming - Part of the Live Timing Library for .NET
 *  Copyright (C) 2009 Liam Lowey
 *  
 *      http://livetiming.turnitin.co.uk/
 *
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  you may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at 
 *  
 *      http://www.apache.org/licenses/LICENSE-2.0 
 *  
 *  Unless required by applicable law or agreed to in writing, software 
 *  distributed under the License is distributed on an "AS IS" BASIS, 
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
 *  See the License for the specific language governing permissions and 
 *  limitations under the License. 
 */

namespace log4net
{
    /// <summary>
    /// Fake logger for Silverlight applications
    /// </summary>
    public interface ILog
    {
        void DebugFormat(string format, params object[] args);
        void Debug(string msg);

        void InfoFormat(string format, params object[] args);
        void Info(string msg);

        void WarnFormat(string format, params object[] args);
        void Warn(string msg);

        void ErrorFormat(string format, params object[] args);
        void Error(string msg);

        bool IsDebugEnabled { get; }
    }
}
